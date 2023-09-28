using ApiCompany.Domain.DTOs;
using ApiCompany.Model;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace ApiCompany.Infraestructure.Repository
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly CompanyContext _context = new CompanyContext();
       private readonly ILogger _logger;

        public void add(Company company)
        {
            _context.Companys.Add(company);
            _context.SaveChanges();
          //  _logger.LogInformation("Adicionado com Sucesso!"); 
        }

        public List<CompanyDTO> get()
        {
                return _context.Companys
                    .Select(g =>
                        new CompanyDTO
                        {
                            IdDTO = g.Id,
                            NameDTO = g.Name,
                            DescriptionDTO = g.Description
                        }
                ).ToList();
        }

        public Company? getIdCompany(int id)
        {
            return _context.Companys.Find(id);
        }

        public Company? putIdCompany(Company? companyOldData, Company? updateCompany)
        {
         //   companyOldData = _context.Companys.Find(id);

            if (companyOldData == null )
            {
                _logger.LogInformation("Company não encontrada.");
                return null;
            }
            else 
            {
                companyOldData.Name = updateCompany.Name;
                companyOldData.Description = updateCompany.Description;

                _context.SaveChanges();
                return companyOldData;
            }
        }

        public void deleteCompany(Company companyRemov)
        {
            _context.Companys.Remove(companyRemov);
            _context.SaveChanges();
        }
    }
}
