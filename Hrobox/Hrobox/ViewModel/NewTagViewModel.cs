using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Hrobox.Command;
using Hrobox.Model;
using Hrobox.Repository;
using Hrobox.Services.Interfaces;
using Hrobox.ViewModel.Interfaces;

namespace Hrobox.ViewModel
{
    public class NewTagViewModel : ViewModelBase, IViewModel<SignInUserModel>
    {
        public Tag Tag { get; set; }
        public SignInUserModel SignInUserModel { get; set; }
        private ICommand createTag;
        public ICommand CreateTag => createTag;
        private readonly INavigationService navigationService;
        private readonly ITagRepository tagRepository;

        public NewTagViewModel(INavigationService navigationService, ITagRepository tagRepository)

        {
            this.createTag = new AsyncCommand(CreateTagCommand, null, null, false);
            this.tagRepository = tagRepository;
            this.Tag = new Tag();
        }

        private async Task CreateTagCommand()
        {
            await tagRepository.CreateTag(this.Tag, this.SignInUserModel.jwt);
        }

        public void SetViewModelParameter(SignInUserModel? parameter)
        {
            SignInUserModel = parameter;
        }
    }

}
