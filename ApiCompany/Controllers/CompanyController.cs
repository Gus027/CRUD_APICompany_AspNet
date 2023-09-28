using ApiCompany.Domain.ViewModel;
using ApiCompany.Infraestructure;
using ApiCompany.Model;
using Microsoft.AspNetCore.Mvc;

namespace ApiCompany.Controllers
{
    [ApiController]
    [Route("api/v1/Company")]
    public class CompanyController : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository ?? throw new ArgumentNullException(nameof(companyRepository));
        }

        [HttpGet]
        public IActionResult GetCompany() {
            var companyGet = _companyRepository.get();
            return Ok(companyGet);
        }
        [HttpPost]
        public IActionResult PostCompany([FromForm] CompanyViewModel companyViewModel)
        {
            var companyPost = new Company(companyViewModel.Name, companyViewModel.Description);
            _companyRepository.add(companyPost);
            return Ok(companyPost);
        }
        [HttpPut]
        public IActionResult PutCompany(int id, string newName, string newDescription) {


            var companyId = _companyRepository.getIdCompany(id);

            var CompanyPut = new Company(newName, newDescription);
            _companyRepository.putIdCompany(companyId, CompanyPut);

            return Ok(companyId);
        }
        [HttpDelete]
        public IActionResult DeleteCompany([FromForm]int id)
        {
            var companyIdRemove = _companyRepository.getIdCompany(id);
            _companyRepository.deleteCompany(companyIdRemove);
            return Ok(companyIdRemove); 
        }

        [HttpGet]
        [Route("{id}/Company")]
        public IActionResult GetIdCompany(int id)
        {
            var companyId = _companyRepository.getIdCompany(id);
            return Ok(companyId);

        }
    }
}
