using Largo_EvaluacionP3.Models;
using Largo_EvaluacionP3.Services_SL;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Largo_EvaluacionP3.ViewModels_SL
{
    public class CharacterViewModel_SL : BaseViewModel
    {
        private readonly NarutoAPIService_SL _apiService;
        private readonly DatabaseService_SL _databaseService;

        public ObservableCollection<CharacterModel_SL> Characters { get; }
        public ICommand LoadCharactersCommand { get; }
        public ICommand SaveCharacterCommand { get; }

        public CharacterViewModel_SL()
        {
            _apiService = new NarutoAPIService_SL();
            _databaseService = new DatabaseService_SL("path_to_db");

            Characters = new ObservableCollection<CharacterModel_SL>();

            LoadCharactersCommand = new Command(async () => await LoadCharactersAsync());
            SaveCharacterCommand = new Command<CharacterModel_SL>(async (character) => await SaveCharacterAsync(character));
        }

        private async Task LoadCharactersAsync()
        {
            var characters = await _apiService.GetCharactersAsync();
            if (characters != null)
            {
                foreach (var character in characters)
                {
                    Characters.Add(character);
                }
            }
        }

        private async Task SaveCharacterAsync(CharacterModel_SL character)
        {
            await _databaseService.SaveCharacterAsync(character);
        }
    }
}
