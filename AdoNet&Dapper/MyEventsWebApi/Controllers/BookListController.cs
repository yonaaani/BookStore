using Dapper_Example.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyEventsAdoNetDb.Entities;
using MyEventsAdoNetDb.Repositories.Contracts;
using MyEventsAdoNetDB.Repositories;
using MyEventsAdoNetDB.Repositories.Contracts;
//using MyEventsEntityFrameworkDb.EFRepositories.Contracts;

namespace MyEventsWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookListController : ControllerBase
    {
        private readonly ILogger<BookListController> _logger;
       // private IEFUnitOfWork _EFuow;
        private IUnitOfWork _ADOuow;
        public BookListController(ILogger<BookListController> logger,
      //      IEFUnitOfWork unitOfWork,
            IUnitOfWork ado_unitofwork)
        {
            _logger = logger;
       //     _EFuow = unitOfWork;
            _ADOuow = ado_unitofwork;
        }

        //GET: api/BookList
        ///
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<BookList>>> GetAllEventsAsync()
        {
            try
            {
                var results = await _ADOuow._booklistRepository.GetAllAsync();
                _ADOuow.Commit();
                _logger.LogInformation($"�������� �� ������ � ���� �����!");
                return Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError($"���������� ����������! ���� ���� �� ��� � ����� GetAllEventsAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "��� ��� ���!");
            }
        }

        //GET: api/BookList/Id
        [HttpGet("{id}")]
        public async Task<ActionResult<BookList>> GetByIdAsync(int id)
        {
            try
            {
                var result = await _ADOuow._booklistRepository.GetAsync(id);
                _ADOuow.Commit();
                if (result == null)
                {
                    _logger.LogInformation($"����� �� Id: {id}, �� ��� ���������� � ��� �����");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"�������� ����� � ���� �����!");
                    return Ok(result);
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"���������� ����������! ���� ���� �� ��� � ����� GetAllEventsAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "��� ��� ���!");
            }
        }

        //POST: api/BookList
        [HttpPost]
        public async Task<ActionResult> PostEventAsync([FromBody] BookList evnt)
        {
            try
            {
                if (evnt == null)
                {
                    _logger.LogInformation($"�� �������� ������ json � ������� �볺���");
                    return BadRequest("���� ������ � null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogInformation($"�� �������� ����������� json � ������� �볺���");
                    return BadRequest("���� ������ � �����������");
                }
                var created_id = await _ADOuow._booklistRepository.AddAsync(evnt);
                _ADOuow.Commit();
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                _logger.LogError($"���������� ����������! ���� ���� �� ��� � ����� PostEventAsync - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "��� ��� ���!");
            }
        }

        //POST: api/BookList/id
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateEventAsync(int id, [FromBody] BookList evnt)
        {
            try
            {
                if (evnt == null)
                {
                    _logger.LogInformation($"�� �������� ������ json � ������� �볺���");
                    return BadRequest("���� ������ � null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogInformation($"�� �������� ����������� json � ������� �볺���");
                    return BadRequest("���� ������ � �����������");
                }

                var event_entity = await _ADOuow._booklistRepository.GetAsync(id);
                if (event_entity == null)
                {
                    _logger.LogInformation($"����� �� Id: {id}, �� ��� ���������� � ��� �����");
                    return NotFound();
                }

                await _ADOuow._booklistRepository.ReplaceAsync(evnt);
                _ADOuow.Commit();
                return StatusCode(StatusCodes.Status204NoContent);
            }
            catch (Exception ex)
            {
                _logger.LogError($"���������� ����������! ���� ���� �� ��� � ����� PostEventAsync - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "��� ��� ���!");
            }
        }

        //GET: api/BookList/Id
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteByIdAsync(int id)
        {
            try
            {
                var event_entity = await _ADOuow._booklistRepository.GetAsync(id);
                if (event_entity == null)
                {
                    _logger.LogInformation($"����� �� Id: {id}, �� ��� ���������� � ��� �����");
                    return NotFound();
                }

                await _ADOuow._booklistRepository.DeleteAsync(id);
                _ADOuow.Commit();
                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"���������� ����������! ���� ���� �� ��� � ����� GetAllEventsAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "��� ��� ���!");
            }
        }

        // GET: api/BookList?bookName={bookName}
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookList>>> GetByBookNameAsync(string bookName)
        {
            try
            {
                var result = await _ADOuow._booklistRepository.GetAllAsync();
                var filteredResult = result.Where(x => x.BookName.ToLower().Contains(bookName.ToLower()));
                _ADOuow.Commit();
                if (!filteredResult.Any())
                {
                    _logger.LogInformation($"����� �� BookName ������� �� ������ ������� ������! ");
                    return NotFound();
                }
                return Ok(filteredResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"���������� ����������! ���� ���� �� ��� � ����� GetByBookNameAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "��� ��� ���!");
            }
        }

        // GET: api/BookList/Author/{authorName}
        [HttpGet("Author/{authorName}")]
        public async Task<ActionResult<IEnumerable<BookList>>> GetByAuthorAsync(string authorName)
        {
            try
            {
                var result = await _ADOuow._booklistRepository.GetByAuthorAsync(authorName);
                _ADOuow.Commit();

                if (result == null || result.Count() == 0)
                {
                    _logger.LogInformation($"����� ������ {authorName} �� �������� � ��� �����");
                    return NotFound();
                }
                else
                {
                    _logger.LogInformation($"�������� ������ ���� ������ {authorName} � ���� �����!");
                    return Ok(result);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"���������� ����������! ���� ���� �� ��� � ����� GetByAuthorAsync() - {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "��� ��� ���!");
            }
        }

        // GET: api/BookList/genre/{genre}
        [HttpGet("genre/{genre}")]
        public async Task<ActionResult<IEnumerable<BookList>>> GetByGenreAsync(string genre)
        {
            try
            {
                var result = await _ADOuow._booklistRepository.GetByGenreAsync(genre);
                _ADOuow.Commit();

                if (result == null || !result.Any())
                {
                    return NotFound($"����� �� ������ {genre} �� ��������");
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"������� �������: {ex.Message}");
            }
        }

    }
}
