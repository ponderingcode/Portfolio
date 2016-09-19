using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Portfolio.Models;
using Portfolio.Models.CodeFirst;
using System.IO;

namespace Portfolio.Controllers
{
    public class BlogPostsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: BlogPosts
        public ActionResult Index()
        {
            var listPosts = db.Posts.AsQueryable();
            //return View(db.Posts.ToList());
            return View(listPosts.OrderByDescending(p => p.Created));
        }

        [HttpPost]
        public ActionResult Index([Bind(Include = "Query")] BlogPost blogPost)
        {
            var result = db.Posts.Where(p => p.Body.Contains(blogPost.Query))
                .Union(db.Posts.Where(p => p.Title.Contains(blogPost.Query)))
                .Union(db.Posts.Where(p => p.Comments.Any(c => c.Body.Contains(blogPost.Query) ||
                                                               c.Author.DisplayName.Contains(blogPost.Query) ||
                                                               c.Author.FirstName.Contains(blogPost.Query) ||
                                                               c.Author.LastName.Contains(blogPost.Query) ||
                                                               c.Author.UserName.Contains(blogPost.Query) ||
                                                               c.Author.Email.Contains(blogPost.Query) ||
                                                               c.UpdateReason.Contains(blogPost.Query))));

            return View(result.OrderByDescending(p => p.Created));
        }

        // GET: BlogPosts/Details/5
        public ActionResult Details(int? id)
        {
            if (null == id)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            BlogPost blogPost = db.Posts.Find(id);
            if (null == blogPost)
            {
                return HttpNotFound();
            }
            //blogPost.Comments = db.Comments.AsQueryable().Where(c => c.PostId.Equals(blogPost.Id));
            //var listComments = db.Comments.AsQueryable();
            //var comments = db.Comments.Include(c => c.Author).AsQueryable().Where(c => c.PostId.Equals(blogPost.Id));
            var comments = db.Comments.Include(c => c.Author);
            List<Comment> CommentsList = new List<Comment>();
            foreach (var item in comments)
            {
                if (blogPost.Id == item.PostId)
                {
                    CommentsList.Add(item);
                }
            }
            blogPost.Comments = CommentsList;
            return View(blogPost);
        }

        [ActionName(ActionName.DETAILS_VIA_SLUG)]
        public ActionResult Details(string Slug)
        {
            if (String.IsNullOrWhiteSpace(Slug))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            BlogPost blogPost = db.Posts.FirstOrDefault(p => p.Slug == Slug);

            if (null == blogPost)
            {
                return HttpNotFound();
            }

            return View("Details", blogPost);
        }

        // GET: BlogPosts/Create
        [Authorize(Roles = UserRole.ADMINISTRATOR)]
        public ActionResult Create()
        {
            return View();
        }

        // POST: BlogPosts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Created,Updated,Title,Slug,Body,MediaURL,Published")] BlogPost blogPost, HttpPostedFileBase image)
        {
            if (null != image && 0 < image.ContentLength)
            {
                string ext = Path.GetExtension(image.FileName).ToLower();
                if (FileType.BMP != ext &&
                    FileType.GIF != ext &&
                    FileType.JPG != ext &&
                    FileType.JPEG != ext &&
                    FileType.PNG != ext)
                {
                    ModelState.AddModelError("image", "Invalid Format.");
                }
            }

            if (ModelState.IsValid)
            {
                blogPost.Created = DateTimeOffset.Now;

                if (null != image)
                {
                    string filePath = "/Uploads/"; // relative server path
                    string absPath = Server.MapPath("~" + filePath); // path on physical drive on server
                    blogPost.MediaURL = filePath + image.FileName; // media URL for relative path
                    image.SaveAs(Path.Combine(absPath, image.FileName));
                }

                string Slug = StringUtilities.URLFriendly(blogPost.Title);
                if (String.IsNullOrWhiteSpace(Slug))
                {
                    ModelState.AddModelError("Title", "Invalid TItle.");
                    return View(blogPost);
                }

                if (db.Posts.Any(p => p.Slug == Slug))
                {
                    ModelState.AddModelError("Title", "The title must be unique.");
                    return View(blogPost);
                }

                blogPost.Slug = Slug;

                db.Posts.Add(blogPost);
                db.SaveChanges();
                return RedirectToAction(ActionName.INDEX);
            }

            return View(blogPost);
        }

        // GET: BlogPosts/Edit/5
        [Authorize(Roles = UserRole.ADMINISTRATOR)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogPost = db.Posts.Find(id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }
            return View(blogPost);
        }

        // POST: BlogPosts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Created,Updated,Title,Slug,Body,MediaURL,Published")] BlogPost blogPost)
        {
            if (ModelState.IsValid)
            {
                blogPost.Updated = DateTimeOffset.Now;
                db.Entry(blogPost).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction(ActionName.INDEX);
            }
            return View(blogPost);
        }

        // GET: BlogPosts/Delete/5
        [Authorize(Roles = UserRole.ADMINISTRATOR)]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BlogPost blogPost = db.Posts.Find(id);
            if (blogPost == null)
            {
                return HttpNotFound();
            }
            return View(blogPost);
        }

        // POST: BlogPosts/Delete/5
        [HttpPost, ActionName(ActionName.DELETE)]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BlogPost blogPost = db.Posts.Find(id);
            db.Posts.Remove(blogPost);
            db.SaveChanges();
            return RedirectToAction(ActionName.INDEX);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
