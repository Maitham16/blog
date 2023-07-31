using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Blog.Data;
using Blog.Models;

namespace Blog.Controllers
{
    public class PostController : Controller
    {
        private readonly BlogContext _context;

        public PostController(BlogContext context)
        {
            _context = context;
        }

        // GET: /Post
        public IActionResult Index()
        {
            List<Post> posts = _context.Posts?.ToList() ?? new List<Post>();
            return View(posts);
        }

        // GET: /Post/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Post? post = _context.Posts?.FirstOrDefault(p => p.Id == id);

            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // GET: /Post/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Post/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Title,ShortDesc,Body")] Post post)
        {
            if (ModelState.IsValid)
            {
                post.Posted = DateTime.Now; // Set the "Posted" property to the current date and time
                if (_context.Posts != null)
                {
                    _context.Posts.Add(post);
                }
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(post);
        }


        // GET: /Post/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Post? post = _context.Posts?.FirstOrDefault(p => p.Id == id);

            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: /Post/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Title,ShortDesc,Body,Posted")] Post updatedPost)
        {
            Post? post = _context.Posts?.FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                // Update only the properties that are allowed for binding
                post.Title = updatedPost.Title;
                post.ShortDesc = updatedPost.ShortDesc;
                post.Body = updatedPost.Body;
                post.Posted = updatedPost.Posted;

                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(post);
        }

        // GET: /Post/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Post? post = _context.Posts?.FirstOrDefault(p => p.Id == id);

            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: /Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Post? post = _context.Posts?.FirstOrDefault(p => p.Id == id);
            if (post == null)
            {
                return NotFound();
            }

            if (_context.Posts != null)
            {
                _context.Posts.Remove(post);
            }
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
