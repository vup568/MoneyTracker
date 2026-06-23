using FinanceTracker.Data;
using FinanceTracker.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinanceTracker.Controllers
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
            var transactionDto = new TransactionDto
            {
                TransactionName = transaction.Title,
                TransactionDate = transaction.TransactionDate.
                Amount = transaction.Amount
            }
            _context.Transactions.Add(transactionDto);

            //create transaction
            await _context.SaveChangesAsync(); //await is waiting for until this complete
            return CreatedAtAction(nameof(GetTransactionById), new {id = transaction.Id}, transaction);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTransactionById(int id){
            var transaction = await _context.Transactions.FindAsync(id);

            if(transaction == null){
                return NotFound();
            }

            var transactionDto = new TransactionDto
            {
                TransactionName = transaction.Title,
                TransactionDate = transaction.TransactionDate.
                Amount = transaction.Amount
            };

            return Ok(transactionDto);
        }
        
        [HttpGet]
        [EnableQuery]
        public IActionResult GetAllTransaction(){
            //this not take all data, just take necessary data
            var transactions = _context.Transactions.Include(t => t.Category).AsQueryable();

            var transactionList = new TransactionDto
            {
                TransactionName = transaction.Title,
                TransactionDate = transaction.TransactionDate.
                Amount = transaction.Amount
            }
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
        public async Task<IActionResult> UpdateTransaction(int id, TransactionDto dto)
        {
            // Bước 1: id trong URL phải khớp với id trong body
            // Tránh trường hợp PUT /api/transactions/5 nhưng body có id = 10
            // if (id != transaction.Id)
            // {
            //     return BadRequest("URL id does not match body id");
            // }

            // Bước 2: Tìm transaction CŨ trong DB
            // Đặt tên "existingTransaction" cho rõ nghĩa — đây là entity đang được EF Core TRACK
            var existingTransaction = await _context.Transactions.FindAsync(id);
            if (existingTransaction == null)
            {
                return NotFound();
            }

            // Bước 3: Validate CategoryId mới có tồn tại không (giống CreateTransaction)
            var category = await _context.Categories.FindAsync(transaction.CategoryId);
            if (category == null)
            {
                return NotFound("CategoryId not found");
            }

            // Bước 4: Cập nhật TỪNG field của entity cũ
            // Tại sao không gán existingTransaction = transaction?
            // → Vì existingTransaction đang được EF Core TRACK, nếu gán lại thì mất tracking
            existingTransaction.Title = dto.TransactionName;
            existingTransaction.Amount = dto.Amount;
            //existingTransaction.Type = dto.Type;
            existingTransaction.TransactionDate = dto.TransactionDate;
            // existingTransaction.Note = transaction.Note;
            // existingTransaction.CategoryId = transaction.CategoryId;

            // Bước 5: SaveChanges — EF Core tự detect field nào thay đổi → chỉ UPDATE những field đó
            await _context.SaveChangesAsync();

            // 204 No Content — chuẩn RESTful cho PUT thành công
            return NoContent();
        }


    }

}