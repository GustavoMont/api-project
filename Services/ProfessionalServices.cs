using api_project.Models;
using Microsoft.AspNetCore.Mvc;
using order_manager.Dto.Professional;
using order_manager.Repositories;
using Mapster;

namespace order_manager.Services;
public class ProfessionalServices
{

    private readonly ProfessionalRepository _repository;

    public ProfessionalServices([FromServices] ProfessionalRepository repository)
    {
        _repository = repository;
    }
    public GetProfessionalRes CreateProfessional(CreateProfessionalReq newProfessional)
    {  
        var professional = newProfessional.Adapt<Professional>();

        _repository.CreateProfessional(professional);

        var reply = professional.Adapt<GetProfessionalRes>();
        return reply;
    }

    public List<GetProfessionalRes> GetAllProfessionals()
    {
        var professionals = _repository.GetAllProfessionals();
        
        var reply = professionals.Adapt<List<GetProfessionalRes>>();

        return reply;
    }

    public GetProfessionalRes GetOneProfessional(int id)
    {
      var professional = _repository.GetOneProfessional(id, false);
      
      return professional.Adapt<GetProfessionalRes>();
    }

    public GetProfessionalRes UpdateProfessional(int id, CreateProfessionalReq updates)
    {
      var professional = GetProfessionalById(id);

      updates.Adapt(professional);

      _repository.UpdateProfessional();

      return professional.Adapt<GetProfessionalRes>();
    }

    public void DeleteProfessional(int id)
    {
      var professional = GetProfessionalById(id);

      _repository.DeleteProfessional(professional);
    }

    private Professional GetProfessionalById(int id, bool tracking = true)
    {
      var professional = _repository.GetOneProfessional(id, tracking);
      if (professional is null)
      {
        throw new Exception("Profissional não encontrado!");
      }

      return professional;
    }
}
