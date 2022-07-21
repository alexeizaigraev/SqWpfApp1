using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqWpfApp1
{
    class Otmena : PapaKabinet
    {


        public static void MainOtmena()
        {
            List<List<string>> data = new List<List<string>>();
            data = GetData();
            //var data = AccBase.AccGetKabinetOtmenaData();

            foreach (var u in data)
            {
                string shablon = $@"<?xml version=""1.0"" encoding=""windows-1251"" standalone=""no""?>
        <DECLAR xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xsi:noNamespaceSchemaLocation=""J1313602.xsd"">
            <DECLARHEAD>
                <TIN>40243180</TIN>
                <C_DOC>J13</C_DOC>
                <C_DOC_SUB>136</C_DOC_SUB>
                <C_DOC_VER>2</C_DOC_VER>
                <C_DOC_TYPE>0</C_DOC_TYPE>
                <C_DOC_CNT>541</C_DOC_CNT>
                <C_REG>26</C_REG>
                <C_RAJ>50</C_RAJ>
                <PERIOD_MONTH>5</PERIOD_MONTH>
                <PERIOD_TYPE>1</PERIOD_TYPE>
                <PERIOD_YEAR>2020</PERIOD_YEAR>
                <C_STI_ORIG>2650</C_STI_ORIG>
                <C_DOC_STAN>1</C_DOC_STAN>
                <LINKED_DOCS xsi:nil=""true""/>
                <D_FILL>17052020</D_FILL>
                <SOFTWARE>CABINET</SOFTWARE>
            </DECLARHEAD>
        <DECLARBODY>
        <HKSTI>2650</HKSTI>
        <HSTI>ГОЛОВНЕ УПРАВЛІННЯ ДФС У М.КИЄВІ, ДПІ У ГОЛОСІЇВСЬКОМУ РАЙОНІ (ГОЛОСІЇВСЬКИЙ РАЙОН М.КИЄВА)</HSTI>
        <HNAME>ТОВАРИСТВО З ОБМЕЖЕНОЮ ВIДПОВIДАЛЬНIСТЮ ""ЕЛЕКТРУМ ПЕЙМЕНТ СІСТЕМ""</HNAME>
        <HTIN>40243180</HTIN>
        <R001G1S>{u[8]}</R001G1S>
        <R002G1S>{u[1]}</R002G1S>
        <R003G1>420</R003G1>
        <R003G1S>{u[2]}</R003G1S>
        <R004G1>1085</R004G1>
        <R004G1S>{u[3]}</R004G1S>
        <R007G1S>{u[4]}</R007G1S>
        <R008G1S>{u[5]}</R008G1S>
        <R009G1>{u[6]}</R009G1>
        <R010G1S>{u[7]}</R010G1S>
        <R011G1S>закриття відділення</R011G1S>
        <R012G1S>{u[8]}</R012G1S>
        <M03>1</M03>
        <M04>1</M04>
        <HKBOS>2903722436</HKBOS>
        <HBOS>ПОЖАРСЬКИЙ ВЯЧЕСЛАВ ЮХИМОВИЧ</HBOS>
        <HFILL>{DateNow()}</HFILL>
        <HZ>1</HZ>
            <HZM>2</HZM>
            <HMONTH>2</HMONTH>
            <HZY>2020</HZY>
        </DECLARBODY>
        </DECLAR>
";


                string ofname = kabinetPath + u[9] + "_otmena_" + u[1] + ".xml";
                TextToFileCP1251(ofname, shablon);
            }
            //Loger("otmena");
        }


        private static List<List<string>> GetData()
        {
            return DbBase.GetData(@"SELECT terminals.ticket_number, terminals.serial_number,
terminals.model, terminals.soft, terminals.rne_rro, 
departments.address, departments.koatu, departments.tax_id,
terminals.fiscal_number, departments.department
FROM otbor, terminals, departments
WHERE otbor.term = terminals.termial
AND departments.department = terminals.department
ORDER BY terminals.termial;");
        }


    }
}
