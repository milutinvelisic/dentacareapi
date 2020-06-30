using DentaCare.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;
using DentaCare.Application.DataTransfer;

namespace DentaCare.Application.Queries
{
    public interface IGetUserQuery : IQuery<UserSearch, PagedResponse<UserDto>>
    {
    }
}
