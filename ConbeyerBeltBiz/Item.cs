using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConbeyerBeltBiz
{
    public delegate void ChangeHasItemEventHandler(string name, bool oldValue, bool newValue);
    public delegate void ChangeLocationEventHandler(string name, string oldValue, string newValue);
    public delegate void ChangeBarcodeEventHandler(string name, string oldValue, string newValue);
    public delegate void ChangeStatusEventHandler(string name, string oldValue, string newValue);
    public delegate void ChangeErrorCodeEventHandler(string name, string oldValue, string newValue);

    public class Item
    {
        public string PairId { get; set; }
        public LabelInfo LabelInfo { get; set; }
        private bool _hasItem = false;
        public bool HasItem
        {
            get
            {
                return this._hasItem;
            }
            set
            {
                if (this._hasItem != value)
                {
                    if (this.ChangeHasItem != null)
                    {
                        bool oldValue = this._hasItem;
                        this._hasItem = value;
                        this.ChangeHasItem(this.LabelInfo.Name, oldValue, value);
                    }
                }
            }
        }

        private string _location = "";
        public string Location
        {
            get
            {
                return this._location;
            }
            set
            {
                if (this._location != value)
                {
                    if (this.ChangeLocation != null)
                    {
                        string oldValue = this._location;
                        this._location = value;
                        this.ChangeLocation(this.LabelInfo.Name, oldValue, value);
                    }
                }
            }
        }

        private string _barcode = "";
        public string Barcode
        {
            get
            {
                return this._barcode;
            }
            set
            {
                if (this._barcode != value)
                {
                    if (this.ChangeBarcode != null)
                    {
                        string oldValue = this._barcode;
                        this._barcode = value;
                        this.ChangeBarcode(this.LabelInfo.Name, oldValue, value);
                    }
                }
            }
        }

        private string _status = "";
        public string Status
        {
            get
            {
                return this._status;
            }
            set
            {
                if (this._status != value)
                {
                    if (this.ChangeStatus != null)
                    {
                        string oldValue = this._status;
                        this._status = value;
                        this.ChangeStatus(this.LabelInfo.Name, oldValue, value);
                    }
                }
            }
        }

        private string _errorCode = "";
        public string ErrorCode
        {
            get
            {
                return this._errorCode;
            }
            set
            {
                if (this._errorCode != value)
                {
                    if (this.ChangeErrorCode != null)
                    {
                        string oldValue = this._errorCode;
                        this._errorCode = value;
                        this.ChangeErrorCode(this.LabelInfo.Name, oldValue, value);
                    }
                }
            }
        }

        public event ChangeHasItemEventHandler ChangeHasItem;
        public event ChangeLocationEventHandler ChangeLocation;
        public event ChangeBarcodeEventHandler ChangeBarcode;
        public event ChangeStatusEventHandler ChangeStatus;
        public event ChangeErrorCodeEventHandler ChangeErrorCode;
    }

    public class LabelInfo
    {
        public string Name { get; set; }
        public Point Location { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Color BackColor { get; set; }

    }
}
