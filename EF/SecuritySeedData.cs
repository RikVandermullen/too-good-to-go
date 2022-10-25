using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace TGTG_EF;
public class SecuritySeedData : ISeedData
{
    private readonly UserManager<IdentityUser> _userManager;

    public SecuritySeedData(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;

    }

    public async Task EnsurePopulated(bool dropExisting = false)
    {
        const string CLAIMNAME_USERTYPE = "UserType";
        //Password must pass policy check otherwise no user is created
        const string PASSWORD = "Secret123$";

        const string EMAIL_WORKER = "canteenworker1@mail.com";
        const string EMAIL_STUDENT = "student1@mail.com";
        const string EMAIL_STUDENT2 = "student2@mail.com";

        var existingUser = await _userManager.FindByNameAsync(EMAIL_WORKER);
        if (existingUser != null)
            await _userManager.DeleteAsync(existingUser);

        existingUser = await _userManager.FindByNameAsync(EMAIL_STUDENT);
        if (existingUser != null)
            await _userManager.DeleteAsync(existingUser);

        existingUser = await _userManager.FindByNameAsync(EMAIL_STUDENT2);
        if (existingUser != null)
            await _userManager.DeleteAsync(existingUser);

        IdentityUser workerUser = await _userManager.FindByIdAsync(EMAIL_WORKER);
        if (workerUser == null)
        {
            workerUser = new IdentityUser() { UserName = EMAIL_WORKER };

            await _userManager.CreateAsync(workerUser, PASSWORD);
            await _userManager.AddClaimAsync(workerUser, new Claim(CLAIMNAME_USERTYPE, "poweruser"));
        }

        IdentityUser studentUser = await _userManager.FindByIdAsync(EMAIL_STUDENT);
        if (studentUser == null)
        {
            studentUser = new IdentityUser() { UserName = EMAIL_STUDENT };

            await _userManager.CreateAsync(studentUser, PASSWORD);
            await _userManager.AddClaimAsync(studentUser, new Claim(CLAIMNAME_USERTYPE, "regularuser"));
        }

        IdentityUser studentUser2 = await _userManager.FindByIdAsync(EMAIL_STUDENT2);
        if (studentUser2 == null)
        {
            studentUser2 = new IdentityUser() { UserName = EMAIL_STUDENT2 };

            await _userManager.CreateAsync(studentUser2, PASSWORD);
            await _userManager.AddClaimAsync(studentUser2, new Claim(CLAIMNAME_USERTYPE, "regularuser"));
        }
    }
}
