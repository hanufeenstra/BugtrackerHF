namespace BugtrackerHF.Models;

public enum Role
{
    SuperAdmin = 0,     // Has SuperAdmin Rights
    Admin = 1,         // Has Admin Rights
    User = 2           // Has User Rights
}

public enum Severity
{
    Critical = 4,
    Major = 3,
    Moderate = 2,
    Minor = 1,
    Cosmetic = 0
}

public enum Status
{
    Unopened = 0,
    Assigned = 1,
    Pending = 2,
    InProgress = 3,
    Testing = 4,
    Resolved = 5,
    Rejected = 6
}