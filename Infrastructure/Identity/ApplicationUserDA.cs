﻿using Application.Interfaces.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Identity
{
    public class ApplicationUserDA //: IApplicationUserDA
    {
        //private readonly UserManager<ApplicationUser> _userManager;
        //private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory;
        //private readonly IAuthorizationService _authorizationService;

        //public ApplicationUserDA(
        //    UserManager<ApplicationUser> userManager,
        //    IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory,
        //    IAuthorizationService authorizationService)
        //{
        //    _userManager = userManager;
        //    _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
        //    _authorizationService = authorizationService;
        //}

        //public async Task<string> GetUserNameAsync(string userId)
        //{
        //    //var user = await _userManager.Users.FirstAsync(u => u.Id == userId);

        //    return "";// user.UserName;
        //}

        //public async Task<(bool Result, string UserId)> CreateUserAsync(string userName, string password)
        //{
        //    var user = new ApplicationUser
        //    {
        //        UserName = userName,
        //        Email = userName,
        //    };

        //    var result = await _userManager.CreateAsync(user, password);

        //    return (result.Succeeded, user.Id);
        //}

        //public async Task<bool> IsInRoleAsync(string userId, string role)
        //{
        //    var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        //    return await _userManager.IsInRoleAsync(user, role);
        //}

        //public async Task<bool> AuthorizeAsync(string userId, string policyName)
        //{
        //    var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        //    var principal = await _userClaimsPrincipalFactory.CreateAsync(user);

        //    var result = await _authorizationService.AuthorizeAsync(principal, policyName);

        //    return result.Succeeded;
        //}

        //public async Task<bool> DeleteUserAsync(string userId)
        //{
        //    var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

        //    if (user != null)
        //    {
        //        return await DeleteUserAsync(user);
        //    }

        //    return false;
        //}

        //public async Task<bool> DeleteUserAsync(ApplicationUser user)
        //{
        //    var result = await _userManager.DeleteAsync(user);

        //    return result.Succeeded ? true : false;
        //}
    }
}
