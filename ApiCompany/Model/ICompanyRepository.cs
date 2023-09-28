using ApiCompany.Domain.DTOs;

namespace ApiCompany.Model
{
    public interface ICompanyRepository
    {

        void add(Company company);

        List<CompanyDTO> get();

        Company? getIdCompany(int id);

        Company? putIdCompany(Company? companyOldData, Company? updateCompany);

        void deleteCompany(Company companyRemov);
    }
}
