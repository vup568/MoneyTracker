using FinanceTracker.Data;
using FinanceTracker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace FinanceTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //cái này giúp cho chúng ta không cần phải viết các validate trực tiếp mà ApiController sẽ bắt cho chúng ta
    // Ngoài ra nó cũng tự động hiểu dữ liệu lấy từ đâu, nếu không có nó thì bạn phải viết thật tường minh là CreateCategory([FromBody] Category category).
    public class CategoriesController : ControllerBase
    {
        private readonly FinanceDbContext _context;

        public CategoriesController(FinanceDbContext context)
        {
            _context = context;
        }
        //EF core create FinanceDbContext and inject, you do not have new FinanceDbContext() anymore

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var categories = await _context.Categories.ToListAsync();
            //when use async + await: API request Server -> return solve other request -> when server response ->API will take that data
            ////-> API will not wait Server return data 
            return Ok(categories);

            //why return IActionResult ? 
            //-> if use List<Category> instead of IActionResult -> Just return Category data
            //else IActionResult -> return Data and status code and something else 
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            _context.Categories.Add(category);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCategoryById), new { id = category.Id }, category);
            //CreatedAtAction(actionName, routeValue, value)
            //Trả về HTTP 201 Created

            //và chỉ cho client biết resource vừa tạo nằm ở đâu

            //IActionResult được dùng vì nó cho phép Controller linh hoạt điều khiển toàn HTTP response 
            //các cái class return Ok(), notFound,... đều Implement IActionResult 
            //IActionResult
            //↓ 
            //ASP.NET Core
            //↓
            //HttpResponse
            //↓
            //HTTP Packet gửi về Client
            //IActionResult không tự tạo Response,
           // ASP.NET Core Runtime dùng IActionResult để tạo Response.

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
           
            var category = await _context.Categories.FindAsync(id); //Find async chỉ dùng cho tìm khóa chính chứ không dùng lambda
            if(category == null){
                return NotFound();
            }

            return Ok(category);

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteById(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            if(category == null){
                return NotFound();
            }

            _context.Categories.Remove(category);

            await _context.SaveChangesAsync();

            return NoContent();

        }
    }
}
