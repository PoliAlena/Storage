using Storage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Windows;

namespace Storage.Services
{
    public class DataService
    {
        private const string DataFile = "data.json";

        public List<Pallet> LoadPallets()
        {
            try
            {
                if (!File.Exists(DataFile))
                    return new List<Pallet>();

                var jsonData = File.ReadAllText(DataFile);
                var jsonOptions = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                return JsonSerializer.Deserialize<List<Pallet>>(json: jsonData, options: jsonOptions);
            }
            catch(FileNotFoundException ex)
            {
                MessageBox.Show("Файл не найден: " + ex.Message);
                return new List<Pallet>();
            }
            catch (JsonException ex)
            {
                MessageBox.Show("Ошибка чтения JSON: " + ex.Message);
                return new List<Pallet>();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Непредвиденная ошибка в работе: " + ex.Message);
                return new List<Pallet>();
            }

        }
    }
}
