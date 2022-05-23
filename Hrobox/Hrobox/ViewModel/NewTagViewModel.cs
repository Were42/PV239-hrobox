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
    public class NewTagViewModel : ViewModelBase
    {
        public Tag Tag { get; set; }
        public ICommand CreateTagCommand { get; set; }
        private readonly INavigationService _navigationService;
        private readonly ITagRepository _tagRepository;
        private readonly IMessageService _messageService;

        public NewTagViewModel(INavigationService navigationService, ITagRepository tagRepository, IMessageService messageService)

        {
            this.CreateTagCommand = new AsyncCommand(CreateTag, null, null, false);
            this._tagRepository = tagRepository;
            this._navigationService = navigationService;
            this._messageService = messageService;
            this.Tag = new Tag();
        }

        private async Task CreateTag()
        {
            var msg = await _tagRepository.CreateTag(this.Tag);
            await _messageService.ShowAsync(msg);
            if (msg.Contains("Success"))
            {
                await _navigationService.PopToRootAsync();
            }
        }
    }

}
