using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Another_SC2_Hack.Classes;

namespace Another_SC2_Hack.Forms
{
    public partial class DetailedOptions : Form
    {
        private string _strForm = null;
        private MainForm _mymain = null;
        public DetailedOptions(string s, MainForm fr)
        {
            _strForm = s;
            _mymain = fr;
            InitializeComponent();
        }

        #region Variables

        private Color _cDefensive,
                      _cMedic,
                      _cDT,
                      _cNexi;

        private bool _bDefensive,
                     _bMedic,
                     _bDT,
                     _bNexi;

        #endregion

        private void DetailedOptions_Load(object sender, EventArgs e)
        {
            InitialDetails(_strForm);
        }

        private void InitialDetails(string s)
        {
            switch (s)
            {
                case "map":
                    Text = "Detailed information about: Maphack";
                    _bDefensive = _mymain._bMapColorDefensive;
                    _bMedic = _mymain._bMapColorMedics;
                    _bDT = _mymain._bMapColorDT;
                    _bNexi = _mymain._bMapColorNexiOcQueen;
                    _cDefensive = _mymain._cMapColorDefensive;
                    _cMedic = _mymain._cMapColorMedics;
                    _cDT = _mymain._cMapColorDT;
                    _cNexi = _mymain._cMapColorNexiOcQueen;

                    cbDefensive.SelectedItem = _bDefensive.ToString();
                    cbMedivacs.SelectedItem = _bMedic.ToString();
                    cbDT.SelectedItem = _bDT.ToString();
                    cbQueenOcNexus.SelectedItem = _bNexi.ToString();
                    btnColorDefensive.Text = _cDefensive.Name;
                    btnColorDefensive.ForeColor = _cDefensive;
                    btnColorMedivac.Text = _cMedic.Name;
                    btnColorMedivac.ForeColor = _cMedic;
                    btnColorDT.Text = _cDT.Name;
                    btnColorDT.ForeColor = _cDT;
                    btnColorNexi.Text = _cNexi.Name;
                    btnColorNexi.ForeColor = _cNexi;
                    break;
            }
        }

        /*** Just close ***/
        private void btnDecline_Click(object sender, EventArgs e)
        {
            Close();
        }

        /*** Save the settings ***/
        private void btnAccept_Click(object sender, EventArgs e)
        {
            SaveSettings();

            Close();
        }

        /*** This will save the settings ***/
        private void SaveSettings()
        {
            _mymain._cMapColorDefensive = _cDefensive;
            _mymain._cMapColorMedics = _cMedic;
            _mymain._cMapColorDT = _cDT;
            _mymain._cMapColorNexiOcQueen = _cNexi;

            _mymain._bMapColorDefensive = _bDefensive;
            _mymain._bMapColorMedics = _bMedic;
            _mymain._bMapColorDT = _bDT;
            _mymain._bMapColorNexiOcQueen = _bNexi;

            _mymain.CreatSaveFile();
        }

        /*** Color for Defensive structure ***/
        private void btnColorDefensive_Click(object sender, EventArgs e)
        {
            var cd = new ColorDialog();

            var res = cd.ShowDialog();

            if (res.Equals(DialogResult.OK))
                _cDefensive = cd.Color;

            btnColorDefensive.Text = _cDefensive.Name;
            btnColorDefensive.ForeColor = _cDefensive;
        }

        /*** Color for Medic and Warp Prism ***/
        private void btnColorMedivac_Click(object sender, EventArgs e)
        {
            var cd = new ColorDialog();

            var res = cd.ShowDialog();

            if (res.Equals(DialogResult.OK))
                _cMedic = cd.Color;

            btnColorMedivac.Text = _cMedic.Name;
            btnColorMedivac.ForeColor = _cMedic;
        }

        /*** Color for DT ***/
        private void btnColorDT_Click(object sender, EventArgs e)
        {
            var cd = new ColorDialog();

            var res = cd.ShowDialog();

            if (res.Equals(DialogResult.OK))
                _cDT = cd.Color;

            btnColorDT.Text = _cDT.Name;
            btnColorDT.ForeColor = _cDT;
        }

        /*** Color for Nexi, OC and Queen ***/
        private void btnColorNexi_Click(object sender, EventArgs e)
        {
            var cd = new ColorDialog();

            var res = cd.ShowDialog();

            if (res.Equals(DialogResult.OK))
                _cNexi = cd.Color;

            btnColorNexi.Text = _cNexi.Name;
            btnColorNexi.ForeColor = _cNexi;
        }

        /*** Activate the Defensive- coloring ***/
        private void cbDefensive_SelectedIndexChanged(object sender, EventArgs e)
        {
            _bDefensive = Convert.ToBoolean(cbDefensive.SelectedItem);
        }

        /*** Activate the Medivac/ Wapr Prism coloring ***/
        private void cbMedivacs_SelectedIndexChanged(object sender, EventArgs e)
        {
            _bMedic = Convert.ToBoolean(cbMedivacs.SelectedItem);
        }

        /*** Activate the DT coloring ***/
        private void cbDT_SelectedIndexChanged(object sender, EventArgs e)
        {
            _bDT = Convert.ToBoolean(cbDT.SelectedItem);
        }

        /*** Activate the Nexi, OC, Queen coloring ***/
        private void cbQueenOcNexus_SelectedIndexChanged(object sender, EventArgs e)
        {
            _bNexi = Convert.ToBoolean(cbQueenOcNexus.SelectedItem);
        }

       
    }
}
