using api_project.Dto.Firm;
using api_project.Models;
using Microsoft.AspNetCore.Mvc;
using order_manager.Dto.Firm;
using order_manager.Repositories;
using Mapster;
using api_project.errors;

namespace order_manager.Services;

public class FirmServices
{
    private FirmRepository _repository;

    public FirmServices([FromServices] FirmRepository repository)
    {
        _repository = repository;
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

    public FirmRes CreateFirm(CreateFirmReq FirmReq)
    {
        var newFirm = FirmReq.Adapt<Firm>();

        _repository.CreateFirm(newFirm);
        return newFirm.Adapt<FirmRes>();
    }

    public List<FirmRes> GetAllFirms()
    {
        var firms = _repository.GetAllFirm();
        if (firms.Count == 0)
        {
            throw new NotFoundException("Firmes não encotrados");
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
