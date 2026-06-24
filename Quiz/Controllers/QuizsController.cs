using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entity.Models;
using Entity.Data;

[Route("api/[controller]")]
[ApiController]
public class QuizsController : ControllerBase
{
    private readonly SchoolDbContext _context;
    public QuizsController(SchoolDbContext context)
    {
        _context = context;
    }

    // GET: api/Quiz
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Quiz>>> GetQuiz()
    {
        return await _context.Quizzes.ToListAsync();
    }

    // GET: api/Quiz/5
    [HttpGet("{quizid}")]
    public async Task<ActionResult<Quiz>> GetQuiz(int quizid)
    {
        var quiz = await _context.Quizzes.FindAsync(quizid);

        if (quiz == null)
        {
            return NotFound();
        }

        return quiz;
    }

    // PUT: api/Quiz/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{quizid}")]
    public async Task<IActionResult> PutQuiz(int? quizid, Quiz quiz)
    {
        if (quizid != quiz.QuizId)
        {
            return BadRequest();
        }

        _context.Entry(quiz).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!QuizExists(quizid))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Quiz
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Quiz>> PostQuiz(Quiz quiz)
    {
        _context.Quizzes.Add(quiz);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetQuiz", new { quizid = quiz.QuizId }, quiz);
    }

    // DELETE: api/Quiz/5
    [HttpDelete("{quizid}")]
    public async Task<IActionResult> DeleteQuiz(int? quizid)
    {
        var quiz = await _context.Quizzes.FindAsync(quizid);
        if (quiz == null)
        {
            return NotFound();
        }

        _context.Quizzes.Remove(quiz);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool QuizExists(int? quizid)
    {
        return _context.Quizzes.Any(e => e.QuizId == quizid);
    }
}
