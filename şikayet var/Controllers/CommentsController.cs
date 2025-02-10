using System;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using şikayet_var.Models.Repository;
using şikayet_var.ViewModels;

namespace şikayet_var.Controllers;

public class CommentsController : Controller
{
private readonly CommentsRepository _commentsRepository;

    public CommentsController(CommentsRepository commentsRepository)
    {
        _commentsRepository = commentsRepository;
    }

    public async Task<IActionResult> Index()
    {
        var comments = await _commentsRepository.GetAllAsync();
        return View(comments);
    }
    public ActionResult Create()
    {
        return View();
    }

     [HttpPost]
     public async Task<ActionResult> Create(CommentsViewModels commentsViewModels)
     {
        if(ModelState.IsValid)
        {
            await _commentsRepository.CreateAsync(commentsViewModels);
            return RedirectToAction("Index");
            
        }
        return View(commentsViewModels);
     }
}
