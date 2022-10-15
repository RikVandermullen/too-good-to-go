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

        const string USERNAME_WORKER = "CanteenWorker1";
        const string USERNAME_STUDENT = "Student1";

        var existingUser = await _userManager.FindByNameAsync(USERNAME_WORKER);
        if (existingUser != null)
            await _userManager.DeleteAsync(existingUser);

        existingUser = await _userManager.FindByNameAsync(USERNAME_STUDENT);
        if (existingUser != null)
            await _userManager.DeleteAsync(existingUser);

        IdentityUser workerUser = await _userManager.FindByIdAsync(USERNAME_WORKER);
        if (workerUser == null)
        {
            workerUser = new IdentityUser() { UserName = USERNAME_WORKER };

            await _userManager.CreateAsync(workerUser, PASSWORD);
            await _userManager.AddClaimAsync(workerUser, new Claim(CLAIMNAME_USERTYPE, "poweruser"));
        }

        IdentityUser studentUser = await _userManager.FindByIdAsync(USERNAME_STUDENT);
        if (studentUser == null)
        {
            studentUser = new IdentityUser() { UserName = USERNAME_STUDENT};

            await _userManager.CreateAsync(studentUser, PASSWORD);
            await _userManager.AddClaimAsync(studentUser, new Claim(CLAIMNAME_USERTYPE, "regularuser"));
        }
    }
}
