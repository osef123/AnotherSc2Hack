using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using Another_SC2_Hack.Classes;
using System.Text;
using System.Windows.Forms;

namespace Another_SC2_Hack.Forms
{
    public partial class Debug_and_Testform : Form
    {
        private MainForm _frm = null;
        public Debug_and_Testform(MainForm fr)
        {
            _frm = fr;
            InitializeComponent();
        }

        private PlayerInfo _pInfo;
        private int _iUnitnum = 0;
        private void Debug_and_Testform_Load(object sender, EventArgs e)
        {


            if (!Various.StarcraftAvailable())
            {
                
                Close();
                return;
            }

            _pInfo = new PlayerInfo(new BufferForm(Typo.BufferformType.Dummy, _frm));
            PrintListbox();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (_iUnitnum <= 0)
                return;

            _iUnitnum--;
            PrintListbox();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_iUnitnum + 1 == _pInfo.UnitTotal())
                return;

            _iUnitnum++;
            PrintListbox();
        }

        private void PrintListbox()
        {
            lstPlayerinfo.Items.Clear();
            lstUnitInfo.Items.Clear();

            

            #region Playerinfo

            lstPlayerinfo.Items.Add("Camera X: " + _pInfo.CameraX(0).ToString());
            lstPlayerinfo.Items.Add("Camera Y: " + _pInfo.CameraY(0).ToString());
            lstPlayerinfo.Items.Add("Camera Distance: " + _pInfo.CameraDistance(0).ToString());
            lstPlayerinfo.Items.Add("Status: " + _pInfo.Status(0).ToString());
            lstPlayerinfo.Items.Add("Namelenght: " + _pInfo.NameLength(0).ToString());
            lstPlayerinfo.Items.Add("Name: " + _pInfo.Name(0));
            lstPlayerinfo.Items.Add("Color: " + _pInfo.Color(0).ToString());
            lstPlayerinfo.Items.Add("Type: " + _pInfo.Type(0).ToString());
            lstPlayerinfo.Items.Add("Apm: " + _pInfo.Apm(0).ToString());
            lstPlayerinfo.Items.Add("EPM: " + _pInfo.Epm(0).ToString());
            lstPlayerinfo.Items.Add("Minerals: " + _pInfo.Minerals(0).ToString());
            lstPlayerinfo.Items.Add("Gas: " + _pInfo.Gas(0).ToString());
            lstPlayerinfo.Items.Add("Minerals Income: " + _pInfo.MineralsIncome(0).ToString());
            lstPlayerinfo.Items.Add("Gas Income: " + _pInfo.GasIncome(0).ToString());
            lstPlayerinfo.Items.Add("Minerals Army: " + _pInfo.MineralsArmy(0).ToString());
            lstPlayerinfo.Items.Add("Gas Army: " + _pInfo.GasArmy(0).ToString());
            lstPlayerinfo.Items.Add("Supply Min: " + (_pInfo.SupplyMin(0)).ToString());
            lstPlayerinfo.Items.Add("Supply Max: " + (_pInfo.SupplyMax(0)).ToString());
            lstPlayerinfo.Items.Add("Workers: " + _pInfo.Workers(0).ToString());
            lstPlayerinfo.Items.Add("Team: " + _pInfo.Team(0).ToString());
            lstPlayerinfo.Items.Add("Race: " + _pInfo.Race(0).ToString());
            lstPlayerinfo.Items.Add("Playercount: " + _pInfo.Playercount().ToString());
            lstPlayerinfo.Items.Add("Localplayer: " + _pInfo.LocalPlayer().ToString());

            #endregion


            lstUnitInfo.Items.Add("Total Units: " + _pInfo.UnitTotal().ToString());
            lstUnitInfo.Items.Add("Pos X: " + _pInfo.UnitPosX(_iUnitnum).ToString());
            lstUnitInfo.Items.Add("Pos Y: " + _pInfo.UnitPosY(_iUnitnum).ToString());
            lstUnitInfo.Items.Add("PosDest X: " + _pInfo.UnitDestPosX(_iUnitnum).ToString());
            lstUnitInfo.Items.Add("PosDest Y: " + _pInfo.UnitDestPosY(_iUnitnum).ToString());
            lstUnitInfo.Items.Add("Owner: " + _pInfo.UnitOwner(_iUnitnum).ToString());
            lstUnitInfo.Items.Add("State: " + _pInfo.UnitState(_iUnitnum).ToString());
            lstUnitInfo.Items.Add("Energy: " + _pInfo.UnitEnergy(_iUnitnum).ToString());
            lstUnitInfo.Items.Add("Target Filter: " + _pInfo.UnitTargetFilter(_iUnitnum).ToString());
            lstUnitInfo.Items.Add("Id: " + _pInfo.UnitId(_iUnitnum).ToString());
            lstUnitInfo.Items.Add("Size: " + _pInfo.UnitSize(_iUnitnum).ToString());

            lblUnitNum.Text = _iUnitnum.ToString();
        }
    }
}
