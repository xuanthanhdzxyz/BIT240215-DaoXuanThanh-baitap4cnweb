using Microsoft.AspNetCore.Mvc;
using Bai6_Validation.Models;

namespace Bai6_Validation.Controllers
{
    public class BookController : Controller
    {
        // Danh sách sách tạm thời (thay vì database)
        private static List<Book> books = new List<Book>();
        private static int nextId = 1;

        // Hiển thị form thêm sách
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // Xử lý thêm sách
        [HttpPost]
        public IActionResult Create(Book book)
        {
            // Kiểm tra ModelState
            if (ModelState.IsValid)
            {
                // Thêm sách mới
                book.Id = nextId++;
                books.Add(book);

                // Chuyển đến trang thành công hoặc danh sách sách
                TempData["SuccessMessage"] = "Thêm sách thành công!";
                return RedirectToAction("Index");
            }

            // Nếu không hợp lệ, trả về form với lỗi
            return View(book);
        }

        // Hiển thị danh sách sách
        public IActionResult Index()
        {
            return View(books);
        }
    }
}