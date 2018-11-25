﻿using Microsoft.AspNetCore.Authorization;

namespace Globalque.Controllers
{
    [Authorize]
    public class ProtectedPeopleController : PeopleController
    {
        // Just reuse another controller, and expose the endpoints in a
        // controller requiring Authorization.

        public ProtectedPeopleController(PeopleDbContext db)
            : base(db)
        { }
    }
}
