using Newtonsoft.Json.Linq;
using Playload.App.Services;
using System.Text;

namespace Playload.App.UI
{
    public partial class AddEditForm : Form
    {
        const string apiKey = "dd2d278ae9f98cb809b48b0ca7cd84d8";
        string domain;
        string _petId;
        string _ownerId;

        FileService fileService = new FileService();
        PetService petService;
        PetTypeService petTypeService;
        BreedService breedService;

        public AddEditForm(string petId, string ownerId)
        {
            InitializeComponent();

            domain = fileService.GetAllDataFromXml().domain;
            petService = new PetService(domain, apiKey);
            petTypeService = new PetTypeService(domain, apiKey);
            breedService = new BreedService(domain, apiKey);
            _petId = petId;
            _ownerId = ownerId;

            if (_petId == "-1")
            {
                buttonSave.Text = "Добавить";
                LoadBasics();
            }
            else
            {
                this.Text = "Редактирование питомца";
                LoadBasics();
                LoadPet();
            }
            Cursor = Cursors.Default;
        }
      
        public async void LoadBasics()
        {
            Cursor = Cursors.WaitCursor;
            comboBoxType.Items.Add(string.Empty);
            comboBoxBreed.Items.Add(string.Empty);
            comboBoxSex.Items.Add(string.Empty);
            comboBoxSex.Items.Add("MALE");
            comboBoxSex.Items.Add("FEMALE");
            comboBoxSex.Items.Add("CASTRATED");
            comboBoxSex.Items.Add("STERIALIZED");
            dateTimePickerBirthday.Text = DateTime.Now.Date.ToString();

            var petTypeJsonResponse = JObject.Parse(await petTypeService.GetPetTypesAsync());
            foreach (var petType in petTypeJsonResponse["data"]["petType"])
            {
                comboBoxType.Items.Add(petType["title"].ToString());
            }
        }

        public async void LoadPet()
        {
            Cursor = Cursors.WaitCursor;
            var petJsonResponse = JObject.Parse(await petService.GetPetByIdAsync(_petId));
            var petTypeJsonResponse = JObject.Parse(await petTypeService.GetPetTypesAsync());
            var breedsJsonResponse = JObject.Parse(await breedService.GetAllBreedsFilteredByPetType(
                petJsonResponse["data"]["pet"]["type_id"].ToString()));
            var breedJsonResponse = JObject.Parse(await breedService.GetBreedById(petJsonResponse["data"]["pet"]["breed_id"].ToString()));
            foreach (var breed in breedsJsonResponse["data"]["breed"])
            {
                comboBoxBreed.Items.Add(breed["title"].ToString());
            }

            textBoxAlias.Text = petJsonResponse["data"]["pet"]["alias"].ToString();
            comboBoxType.SelectedItem = petJsonResponse["data"]["pet"]["type"]["title"].ToString();
            comboBoxBreed.SelectedItem = breedJsonResponse["data"]["breed"]["title"].ToString();
            comboBoxSex.SelectedItem = petJsonResponse["data"]["pet"]["sex"].ToString().ToUpper();
            string date = "";
            date = petJsonResponse["data"]["pet"]["birthday"].ToString();
            if(date == "0000-00-00")
            {
                date = "";
            }
            dateTimePickerBirthday.Text = date;

        }

        private async void comboBoxType_DropDownClosed(object sender, EventArgs e)
        {
            if ((sender as ComboBox).SelectedIndex > 0)
            {
                comboBoxBreed.Items.Clear();
                comboBoxBreed.Items.Add(string.Empty);
                comboBoxBreed.Text = string.Empty;
                var breedsJsonResponse = JObject.Parse(await breedService.GetAllBreedsFilteredByPetType(
                    (sender as ComboBox).SelectedIndex.ToString()));
                foreach (var breed in breedsJsonResponse["data"]["breed"])
                {
                    comboBoxBreed.Items.Add(breed["title"].ToString());
                }

            }
            else
            {
                comboBoxBreed.Items.Clear();
                comboBoxBreed.Items.Add(string.Empty);
                comboBoxBreed.Text = string.Empty;

            }

        }

        private async void buttonSave_Click(object sender, EventArgs e)
        {
            StringBuilder error = new StringBuilder();
            string? alias = textBoxAlias.Text;
            string? type_id = comboBoxType.SelectedIndex.ToString();
            string? sex = "";
            string? breed_id = "-1";
            if (comboBoxSex.SelectedIndex > 0)
            {
                sex = comboBoxSex.SelectedItem.ToString().ToLower();
            }
            string? birthday =$"{DateTime.Parse( dateTimePickerBirthday.Text).Year}-" +
                $"{DateTime.Parse(dateTimePickerBirthday.Text).Month}-" +
                $"{DateTime.Parse(dateTimePickerBirthday.Text).Day}" ;

            if (comboBoxBreed.SelectedIndex > 0)
            {
                var breed = JObject.Parse(await breedService.GetBreedIdByTitle(comboBoxBreed.Text));
                breed_id = breed["data"]["breed"][0]["id"].ToString();
            }
            if (string.IsNullOrEmpty(alias))
            {
                error.AppendLine("Поле кличка обязательное для заполнение");
            }
            if (type_id == "-1")
            {
                error.AppendLine("Поле вид обязательное для заполнения");
            }
            if (breed_id == "-1")
            {
                error.AppendLine("Поле порода обязательное для заполнения");
            }
            if (error.Length > 0)
            {
                MessageBox.Show(error.ToString());
                return;
            }
            if (_petId == "-1")
            {
                await petService.AddPetAsync(_ownerId, breed_id, type_id, alias, sex, birthday);
                MessageBox.Show("Питомец успешно добавлен");
                this.Close();
            }
            else
            {
                await petService.EditPetAsync(_petId, _ownerId, breed_id, type_id, alias, sex, birthday);
                MessageBox.Show("Питомец успешно сохранен");
                this.Close();
            }

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
