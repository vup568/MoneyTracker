using PersonalLifeOS.Infrastructure.Persistence;
using PersonalLifeOS.Domain.Finance;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OData.Query;
using PersonalLifeOS.Application.Finance.DTOs;


namespace PersonalLifeOS.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly FinanceDbContext _context;

         public TransactionsController(FinanceDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTransaction(Transaction transaction)
        {
            if(transaction.Amount <= 0){
                return BadRequest("Amount must greater than 0");
            }
            //find CategoryId, if notFound => badRequest return 404
            var category = await _context.Categories.FindAsync(transaction.CategoryId);
            if(category == null){
                return NotFound("CategoryId not found");
            }
            _context.Transactions.Add(transaction);

            //create transaction
            await _context.SaveChangesAsync(); //await is waiting for until this complete

            var transactionDto = new TransactionDto
            {
                Id = transaction.Id,
                TransactionName = transaction.Title ?? "",
                Amount = transaction.Amount,
                TransactionType = transaction.Type.ToString(),
                TransactionDate = transaction.TransactionDate,
                Note = transaction.Note,
                CategoryId = transaction.CategoryId,
                CategoryName = category.CategoryName
            };

            return CreatedAtAction(nameof(GetTransactionById), new {id = transaction.Id}, transactionDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactionById(int id){
            var transaction = await _context.Transactions
                .Include(t => t.Category)
                .FirstOrDefaultAsync(t => t.Id == id);

            if(transaction == null){
                return NotFound();
            }

            var transactionDto = new TransactionDto
            {
                Id = transaction.Id,
                TransactionName = transaction.Title ?? "",
                Amount = transaction.Amount,
                TransactionType = transaction.Type.ToString(),
                TransactionDate = transaction.TransactionDate,
                Note = transaction.Note,
                CategoryId = transaction.CategoryId,
                CategoryName = transaction.Category?.CategoryName
            };

            return Ok(transactionDto);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAllTransaction(){
            //truy vấn lấy toàn bộ danh sách của Transaction trước
            var transactions = await _context.Transactions.Include(t => t.Category).ToListAsync();

//lúc này mới thực hiện map từ object vào thằng list để hiển thị 
            var transactionList = transactions.Select(t => new TransactionDto
            {
                Id = t.Id,
                TransactionName = t.Title ?? "",
                Amount = t.Amount,
                TransactionType = t.Type.ToString(),
                TransactionDate = t.TransactionDate,
                Note = t.Note,
                CategoryId = t.CategoryId,
                CategoryName = t.Category != null ? t.Category.CategoryName : ""
            });
            return Ok(transactionList);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransactionById(int id){
            var transaction = await _context.Transactions.FindAsync(id);
            if(transaction == null){
                return NotFound();
            }

             _context.Transactions.Remove(transaction);
             await _context.SaveChangesAsync();
             return NoContent();
        }

        [HttpPut("{id}")]
        //Task<T> = lời hứa sẽ trả về T sau khi async hoàn thành
        public async Task<IActionResult> UpdateTransaction(int id, TransactionCreateDto transaction)
        {
            // Bước 1: id trong URL phải khớp với id trong body
            //if (id != transaction.Id)
            //{
            //    return BadRequest("URL id does not match body id");
            //}

            // Bước 2: Tìm transaction CŨ trong DB
            var existingTransaction = await _context.Transactions.FindAsync(id);
            if (existingTransaction == null)
            {
                return NotFound();
            }

            // Bước 3: Validate CategoryId mới có tồn tại không
            var category = await _context.Categories.FindAsync(transaction.CategoryId);
            if (category == null)
            {
                return NotFound("CategoryId not found");
            }

            // Bước 4: Cập nhật TỪNG field của entity cũ
            existingTransaction.Title = transaction.Title;
            existingTransaction.Amount = transaction.Amount;
            existingTransaction.Type = transaction.Type;
            existingTransaction.TransactionDate = transaction.TransactionDate;
            existingTransaction.Note = transaction.Notes;
            existingTransaction.CategoryId = transaction.CategoryId;

            // Bước 5: SaveChanges
            await _context.SaveChangesAsync();

            // 204 No Content — chuẩn RESTful cho PUT thành công
            return NoContent();
        }


    }

}