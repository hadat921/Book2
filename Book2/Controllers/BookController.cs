using Book2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Book2.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult ListBook()
        {
            BookManagerContext context = new BookManagerContext();
            var listBook = context.Book.ToList();
            return View(listBook);
        }

        //create
        public ActionResult CreateBook()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateBook(Book book)
        {
            BookManagerContext context = new BookManagerContext();
            context.Book.AddOrUpdate(book); //Add or Update Book b
            context.SaveChanges();
            return RedirectToAction("ListBook"); // tên của cái hàm mà mình muốn trở về khi thành công -> tự động chuyển trang từ create sang listbook
        }
        [Authorize]
        public ActionResult Buy(int id)
        {
            BookManagerContext context = new BookManagerContext();
            Book book = context.Book.SingleOrDefault(p => p.ID == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);


        }

        public ActionResult Edit(int id)
        {
            BookManagerContext context = new BookManagerContext();
            Book book = context.Book.SingleOrDefault(p => p.ID == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            BookManagerContext context = new BookManagerContext();
            Book bookUpdate = context.Book.SingleOrDefault(p => p.ID == book.ID);
            if (bookUpdate != null)
            {
                //bạn quên set primary cho table nên mới dẫn đến tình trạng sai lúc edit
                context.Book.AddOrUpdate(book);
                context.SaveChanges();
            }
            return RedirectToAction("ListBook");
        }
        public ActionResult Delete(int id)
        {
            BookManagerContext context = new BookManagerContext();
            Book book = context.Book.SingleOrDefault(p => p.ID == id);
            if (book == null)
            {
                return HttpNotFound();

            }
            return View(book);
        }
        [Authorize] 
        [HttpPost]
        public ActionResult DeleteBook(int id)
        {
            BookManagerContext context = new BookManagerContext();
            Book book = context.Book.SingleOrDefault(p => p.ID == id);
            if (book != null)
            {
                context.Book.Remove(book);
                context.SaveChanges();

            }
            return RedirectToAction("ListBook");
        }
        
    }


}
