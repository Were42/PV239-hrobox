using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Hrobox.Model;

namespace Hrobox.Repository
{
    public interface ITagRepository
    {
        Task<TagsModel> GetAllTags();
        Task<string> CreateTag(Tag tag, string jwt);
    }
}
