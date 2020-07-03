﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OktaSolution.Models;
using OktaSolution.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace OktaSolution.Controllers
{
    [Authorize]
    public class SubmissionController : Controller
    {
        private readonly SubmissionService _subSvc;

        public SubmissionController(SubmissionService submissionService)
        {
            _subSvc = submissionService;
        }

        [AllowAnonymous]
        public ActionResult<IList<SubMission>> Index() => View(_subSvc.Read());

        [HttpGet]
        public ActionResult Create() => View();

        [HttpGet]
        public ActionResult<SubMission> Edit(string id) => View(_subSvc.Find(id));

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult<SubMission> Create(SubMission submission)
        {
            submission.Created = submission.LastUpdated = DateTime.Now;
            submission.UserId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
            submission.UserName = User.Identity.Name;
            if (ModelState.IsValid)
            {
                _subSvc.Create(submission);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SubMission submission)
        {
            submission.LastUpdated = DateTime.Now;
            submission.Created = submission.Created.ToLocalTime();
            if (ModelState.IsValid)
            {
                if (User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value != submission.UserId)
                {
                    return Unauthorized();
                }
                _subSvc.Update(submission);
                return RedirectToAction("Index");
            }
            return View(submission);
        }

        [HttpGet]
        public ActionResult Delete(string id)
        {
            _subSvc.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
