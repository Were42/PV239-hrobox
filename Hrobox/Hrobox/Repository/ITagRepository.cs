using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hrobox.Model;

namespace Hrobox.Repository
{
    internal interface ITagRepository
    {
        Task<TagsModel> GetAllTags();
        Task CreateTag(Tag tag);
    }
}
