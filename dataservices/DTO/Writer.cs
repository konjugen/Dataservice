using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace dataservices.DTO
{
    public class Writer
    {
        public int PkWriter { get; set; }
        public string WriterName { get; set; }
        public string Content { get; set; }
        public string FkCategoryId { get; set; }
        public bool IsDaily { get; set; }
    }
}