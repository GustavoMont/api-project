using api_project.Dto.Firm;
using api_project.Models;
using api_project.errors;
using Microsoft.AspNetCore.Mvc;
using api_project.Repositories;
using Mapster;
using api_project.Dto.Login;

namespace api_project.Services;

public class FirmServices
{
    private FirmRepository _repository;
    private TokenService _tokenService;

    public FirmServices(
        [FromServices] FirmRepository repository,
        [FromServices] TokenService tokenService
    )
    {
        _repository = repository;
        _tokenService = tokenService;
    }

    public Firm GetFirmById(int id, bool tracking = true)
    {
        var firm = _repository.GetOneFirm(id, tracking);
        if (firm is null)
        {
            throw new NotFoundException("Empresa não encontrado");
        }
        return firm;
    }

    public TokenRes GetTokenRes(Firm firm)
    {
        var token = _tokenService.GenerateToken(firm);
        var response = new TokenRes { Access = token };
        return response;
    }

    public TokenRes CreateFirm(CreateFirmReq FirmReq)
    {
        if (FirmReq.Password != FirmReq.ConfirmPassword)
        {
            throw new BadHttpRequestException("As senhas não estão iguais");
        }
        var existFirm = _repository.GetByCnpjOrEmail(FirmReq.Email, FirmReq.Cnpj);
        if (existFirm is not null)
        {
            throw new BadHttpRequestException("Empresa já cadastrada");
        }
        var newFirm = FirmReq.Adapt<Firm>();
        newFirm.Password = BCrypt.Net.BCrypt.HashPassword(newFirm.Password);
        var firm = _repository.CreateFirm(newFirm);
        return GetTokenRes(firm);
    }

    public TokenRes Login(LoginReq login)
    {
        var firm = _repository.GetByCnpjOrEmail(login.Credential, login.Credential);
        if (firm is null)
        {
            throw new BadHttpRequestException("Usuário ou senha incorretos");
        }
        if (!BCrypt.Net.BCrypt.Verify(login.Password, firm.Password))
        {
            throw new BadHttpRequestException("Usuário ou senha incorreto");
        }
        firm.Password = "";
        return GetTokenRes(firm);
    }

    public List<FirmRes> GetAllFirms()
    {
        var firms = _repository.GetAllFirm();
        if (firms.Count == 0)
        {
            throw new NotFoundException("Firms não encotrados");
        }

        return firms.Adapt<List<FirmRes>>();
    }

    public FirmRes GetOneFirm(int id, bool tracking = true)
    {
        var firm = GetFirmById(id, false);
        FirmRes firmResponse = new();
        return firm.Adapt(firmResponse);
    }

    public FirmRes UpdateFirm(int id, CreateFirmReq updates)
    {
        var firm = GetFirmById(id);
        firm.Update();
        var firmUpdate = updates.Adapt(firm);
        FirmRes firmRes = new();
        _repository.UpdateFirm();
        return firmUpdate.Adapt(firmRes);
    }

    public void DeleteFirm(int id)
    {
        var firm = GetFirmById(id);
        _repository.DeleteFirm(firm);
        return;
    }
}
