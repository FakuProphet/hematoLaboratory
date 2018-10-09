using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HematoLab.Clases
{
    class Estudio
    {
    
        public int legajoProfesional { get; set; }
        public int numeroDocumento { get; set; }  
        public int codigoGrupoEtario { get; set; }
        public int codigoGenero { get; set; }
        public string cantidadGBWB { get; set; }
        public string cantidadGRRBC { get; set; }
        public string cantidadHB { get; set; }
        public string cantidadHTO { get; set; }
        public string cantidadVCM { get; set; }
        public string cantidadHCM { get; set; }
        public string cantidadCHCM { get; set; }
        public string cantidadRDW { get; set; }
        public string cantidadPLT { get; set; }
        public string cantidadVPM { get; set; }
        public string cantidadBlasto { get; set; }
        public string cantidadPromielocito { get; set; }
        public string cantidadMielocito { get; set; }
        public string cantidadMetamielocito { get; set; }
        public string cantidadNeutrofiloCayado { get; set; }
        public string cantidadNeutrofiloSegmetado { get; set; }
        public string cantidadEosinofilos { get; set; }
        public string cantidadBasofilos { get; set; }
        public string cantidadLinfocitos { get; set; }
        public string cantidadMonocito { get; set; }
        public string cantidadLinfocitoReactivo { get; set; }
        public string cantidadCelulaPlasmatica { get; set; }
        public string cantidadEritroblasto { get; set; }
        public string Alt1L { get; set; }
        public string Alt1SevL { get; set; }
        public string Alt2L { get; set; }
        public string Alt2SevL { get; set; }
        public string eosinofilia { get; set; }
        public string monocitosis { get; set; }
        public string Alt3L { get; set; }
        public string GTNC { get; set; }
        public string SOVNS { get; set; }
        public string SOSG { get; set; }
        public string SOCD { get; set; }
        public string observacionesSerieLeucocitaria { get; set; }
        public string Alt1E { get; set; }
        public string Alt1SevE { get; set; }
        public string Alt2E { get; set; }
        public string Alt2SevE { get; set; }
        public string Alt3E { get; set; }
        public string Alt3SevE { get; set; }
        public string Alt4E { get; set; }
        public string Alt4SevE { get; set; }
        public string Alt5E { get; set; }
        public string Alt5SevE { get; set; }
        public string Alt6E { get; set; }
        public string Alt6SevE { get; set; }
        public string esferocitos { get; set; }
        public string dacriocitos { get; set; }
        public string targetCell { get; set; }
        public string estomatocitos { get; set; }
        public string esquistocitos { get; set; }
        public string esquistocitosPorcentaje { get; set; }
        public string eliptocitos { get; set; }
        public string drepanocitos { get; set; }
        public string equinocito { get; set; }
        public string punteadoBasofilo { get; set; }
        public string anillosDeCabot { get; set; }
        public string cuerposDeHJ { get; set; }
        public string obsSerieEritrocitaria { get; set; }
        public string Alt1P { get; set; }
        public string Alt1SevP { get; set; }
        public string macroplaquetas { get; set; }
        public string obsSeriePlaquetaria { get; set; }
        public string valAbsReti { get; set; }


        public Estudio(int legajoProfesional, int numeroDocumento, int codigoGrupoEtario, int codigoGenero, string cantidadGBWB, string cantidadGRRBC, string cantidadHB, string cantidadHTO, string cantidadVCM, string cantidadHCM, string cantidadCHCM, string cantidadRDW, string cantidadPLT, string cantidadVPM, string cantidadBlasto, string cantidadPromielocito, string cantidadMielocito, string cantidadMetamielocito, string cantidadNeutrofiloCayado, string cantidadNeutrofiloSegmetado, string cantidadEosinofilos, string cantidadBasofilos, string cantidadLinfocitos, string cantidadMonocito, string cantidadLinfocitoReactivo, string cantidadCelulaPlasmatica, string cantidadEritroblasto, string alt1L, string alt1SevL, string alt2L, string alt2SevL, string eosinofilia, string monocitosis, string alt3L, string gTNC, string sOVNS, string sOSG, string sOCD, string observacionesSerieLeucocitaria, string alt1E, string alt1SevE, string alt2E, string alt2SevE, string alt3E, string alt3SevE, string alt4E, string alt4SevE, string alt5E, string alt5SevE, string alt6E, string alt6SevE, string esferocitos, string dacriocitos, string targetCell, string estomatocitos, string esquistocitos, string esquistocitosPorcentaje, string eliptocitos, string drepanocitos, string equinocito, string punteadoBasofilo, string anillosDeCabot, string cuerposDeHJ, string obsSerieEritrocitaria, string alt1P, string alt1SevP, string macroplaquetas, string obsSeriePlaquetaria,string vAbsReti)
        {
            this.legajoProfesional = legajoProfesional;
            this.numeroDocumento = numeroDocumento;
          
            this.codigoGrupoEtario = codigoGrupoEtario;
            this.codigoGenero = codigoGenero;
            this.cantidadGBWB = cantidadGBWB;
            this.cantidadGRRBC = cantidadGRRBC;
            this.cantidadHB = cantidadHB;
            this.cantidadHTO = cantidadHTO;
            this.cantidadVCM = cantidadVCM;
            this.cantidadHCM = cantidadHCM;
            this.cantidadCHCM = cantidadCHCM;
            this.cantidadRDW = cantidadRDW;
            this.cantidadPLT = cantidadPLT;
            this.cantidadVPM = cantidadVPM;
            this.cantidadBlasto = cantidadBlasto;
            this.cantidadPromielocito = cantidadPromielocito;
            this.cantidadMielocito = cantidadMielocito;
            this.cantidadMetamielocito = cantidadMetamielocito;
            this.cantidadNeutrofiloCayado = cantidadNeutrofiloCayado;
            this.cantidadNeutrofiloSegmetado = cantidadNeutrofiloSegmetado;
            this.cantidadEosinofilos = cantidadEosinofilos;
            this.cantidadBasofilos = cantidadBasofilos;
            this.cantidadLinfocitos = cantidadLinfocitos;
            this.cantidadMonocito = cantidadMonocito;
            this.cantidadLinfocitoReactivo = cantidadLinfocitoReactivo;
            this.cantidadCelulaPlasmatica = cantidadCelulaPlasmatica;
            this.cantidadEritroblasto = cantidadEritroblasto;
            Alt1L = alt1L;
            Alt1SevL = alt1SevL;
            Alt2L = alt2L;
            Alt2SevL = alt2SevL;
            this.eosinofilia = eosinofilia;
            this.monocitosis = monocitosis;
            Alt3L = alt3L;
            GTNC = gTNC;
            SOVNS = sOVNS;
            SOSG = sOSG;
            SOCD = sOCD;
            this.observacionesSerieLeucocitaria = observacionesSerieLeucocitaria;
            Alt1E = alt1E;
            Alt1SevE = alt1SevE;
            Alt2E = alt2E;
            Alt2SevE = alt2SevE;
            Alt3E = alt3E;
            Alt3SevE = alt3SevE;
            Alt4E = alt4E;
            Alt4SevE = alt4SevE;
            Alt5E = alt5E;
            Alt5SevE = alt5SevE;
            Alt6E = alt6E;
            Alt6SevE = alt6SevE;
            this.esferocitos = esferocitos;
            this.dacriocitos = dacriocitos;
            this.targetCell = targetCell;
            this.estomatocitos = estomatocitos;
            this.esquistocitos = esquistocitos;
            this.esquistocitosPorcentaje = esquistocitosPorcentaje;
            this.eliptocitos = eliptocitos;
            this.drepanocitos = drepanocitos;
            this.equinocito = equinocito;
            this.punteadoBasofilo = punteadoBasofilo;
            this.anillosDeCabot = anillosDeCabot;
            this.cuerposDeHJ = cuerposDeHJ;
            this.obsSerieEritrocitaria = obsSerieEritrocitaria;
            Alt1P = alt1P;
            Alt1SevP = alt1SevP;
            this.macroplaquetas = macroplaquetas;
            this.obsSeriePlaquetaria = obsSeriePlaquetaria;
            this.valAbsReti = valAbsReti;
        }

        public Estudio() { }
    }
}
