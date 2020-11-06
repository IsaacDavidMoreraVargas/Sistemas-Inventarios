using System;
using System.Collections.Generic;
using System.Text;

namespace SISTEMA_DE_INVENTARIOS
{
    public class paths_Basements
    {
        string corepathFolderDocument;
        string corepathFolderDocumentandRegisterMaterials;
        string corepathFolderDocumentandRegisterSells;
        string corepathFolderDocumentandRegisterInstruments;
        string corepathFolderDocumentandRegisterMetric;
        public string pathFolderDocument
        {
            get { return corepathFolderDocument; }
            set { corepathFolderDocument = value; }
        }

        public string pathFolderDocumentandRegisterMaterials
        {
            get { return corepathFolderDocumentandRegisterMaterials; }
            set { corepathFolderDocumentandRegisterMaterials = value; }
        }

        public string pathFolderDocumentandRegisterSells
        {
            get { return corepathFolderDocumentandRegisterSells; }
            set { corepathFolderDocumentandRegisterSells = value; }
        }

        public string pathFolderDocumentandRegisterInstruments
        {
            get { return corepathFolderDocumentandRegisterInstruments; }
            set { corepathFolderDocumentandRegisterInstruments = value; }
        }

        public string pathFolderDocumentandRegisterMetric
        {
            get { return corepathFolderDocumentandRegisterMetric; }
            set { corepathFolderDocumentandRegisterMetric = value; }
        }

        string specificpathFoldeInstrumentsInches;
        string specificpathFoldeInstrumentsMetric;
        string specificpathFoldeInstrumentsMaterial;

        public string pathFolderInstrumentsAndInches
        {
            get { return specificpathFoldeInstrumentsInches; }
            set { specificpathFoldeInstrumentsInches = value; }
        }
        public string pathFolderInstrumentsAndMetrics
        {
            get { return specificpathFoldeInstrumentsMetric; }
            set { specificpathFoldeInstrumentsMetric = value; }
        }
        public string pathFolderInstrumentsAndMaterial
        {
            get { return specificpathFoldeInstrumentsMaterial; }
            set { specificpathFoldeInstrumentsMaterial = value; }
        }
    }
}
