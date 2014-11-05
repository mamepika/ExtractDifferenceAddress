using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtractDifferenceAddress.Servicies;


namespace ExtractDifferenceAddress.Controllers
{
    public class ExtractDifferenceController
    {
        private MainForm _mainForm;


        private List<string> _addressFiles;

        public ExtractDifferenceController(string folderPath,MainForm form)
        {
            _addressFiles = System.IO.Directory.GetFiles(folderPath, "*.accdb").ToList();
            _mainForm = form;

        }

        public void Execute()
        {
            _mainForm.SetProgressBarValue(_addressFiles.Count);
            _addressFiles.ForEach(file =>
                {
                    var extractService = new ExtractDifferenceService(file);
                    //extractService.ExtractDifference();
                    _mainForm.UpdateProgressBar();
                });
        }
    }
}
