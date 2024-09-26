using Microsoft.AspNetCore.Mvc;
using Ivan1.Interfases.StudentsInterfaces;
using Ivan1.Filters.StudentFilters;
using Ivan1.ServiceExtensions;
using Ivan1.Controllers;

namespace Ivan1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly ILogger<StudentsController> logger;
        private readonly IStudentService _studentService;

        public StudentsController(ILogger<StudentsController> logger, IStudentService studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }

        [HttpPost(Name = "GetStudentsByGroup")]
        public async Task<IActionResult> GetStudentByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken) 
        {
            var students = await _studentService.GetStudentByGroupAsync(filter, cancellationToken);

            return Ok(students);

		}
        
    }
}
