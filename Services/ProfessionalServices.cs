using api_project.Models;
using Microsoft.AspNetCore.Mvc;
using order_manager.Dto.Professional;
using order_manager.Repositories;

namespace order_manager.Services;
public class ProfessionalServices
{

    private ProfessionalRepository _repository;

    public ProfessionalServices([FromServices] ProfessionalRepository repository)
    {
        _repository = repository;
    }
    public GetProfessionalRes CreateProfessional(CreateProfessionalReq newProfessional)
    {
        var professional = new Professional();
        ConvertResToModel(newProfessional, professional);   

        _repository.CreateProfessional(professional);

        var reply = ConverModelToRes(professional);

        return reply;
    }

    public List<GetProfessionalRes> GetAllProfessionals()
    {
        var professionals = _repository.GetAllProfessionals();

        List<GetProfessionalRes> professionalRes = new();

        foreach(var professional in professionals)
        {
          var reply = ConverModelToRes(professional);
          professionalRes.Add(reply);
        }

        return professionalRes;
    }

    public GetProfessionalRes GetOneProfessional(int id)
    {
      var professional = _repository.GetOneProfessional(id);
      return ConverModelToRes(professional);
    }

    public GetProfessionalRes UpdateProfessional(int id, CreateProfessionalReq updates)
    {
      var professional = _repository.GetOneProfessional(id);

      if (professional is null)
      {
        return null; 
      }

      ConvertResToModel(updates, professional);

      _repository.UpdateProfessional();

      return ConverModelToRes(professional);
    }

    public void DeleteProfessional(int id)
    {
      var professional = _repository.GetOneProfessional(id);
      if (professional is null)
      {
        return ;
      }

      _repository.DeleteProfessional(professional);
    }

    private GetProfessionalRes ConverModelToRes(Professional model)
    {
        var reply = new GetProfessionalRes();
        reply.Id = model.Id;
        reply.Ocupation = model.Ocupation;
        reply.Name = model.Name;
        reply.Email = model.Email;

        return reply;
    }

    private void ConvertResToModel(CreateProfessionalReq request, Professional model)
    {
      model.Ocupation = request.Ocupation;
      model.Name = request.Name;
      model.Email = request.Email;
      model.Password = request.Password;
    }
}
