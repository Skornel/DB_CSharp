using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace CD_ROM
{
    public class SearchResultDrawer
    {
        int coordY, coordX;
        Panel panel;
        int labelIndex;
        int currentDisk;
        public SearchResultDrawer(Panel panel)
        {
            this.panel = panel;
            PanelClear();
        }
        private void PanelClear()
        {
            panel.Controls.Clear();
            labelIndex = 0;
            coordY = 10;
            coordX = 10;
        }
        public void DrawSearchResult(List<SearchResult> searchResults)
        {
            PanelClear();
            for (int resultIndex = 0; resultIndex < searchResults.Count; )
            {
                // ID Диска
                currentDisk = searchResults[resultIndex].DiskID;
                panel.Controls.Add(new Label());
                ((Label)panel.Controls[labelIndex]).Text = "Диск №" + searchResults[resultIndex].DiskID.ToString();
                ((Label)panel.Controls[labelIndex]).Font = new Font("Univers Else", 16);
                ((Label)panel.Controls[labelIndex]).ForeColor = Color.Gray;
                ((Label)panel.Controls[labelIndex]).Location = new Point(coordX, coordY - panel.VerticalScroll.Value);
                ((Label)panel.Controls[labelIndex]).AutoSize = true;
                labelIndex++;
                // Примечание диска
                panel.Controls.Add(new Label());
                ((Label)panel.Controls[labelIndex]).Text = searchResults[resultIndex].DiskDescription;
                ((Label)panel.Controls[labelIndex]).Font = new Font("Univers Else", 16, FontStyle.Bold);
                ((Label)panel.Controls[labelIndex]).ForeColor = Color.Black;
                ((Label)panel.Controls[labelIndex]).Location = new Point(
                    ((Label)panel.Controls[labelIndex-1]).Location.X + ((Label)panel.Controls[labelIndex-1]).Size.Width + 10,
                    coordY - panel.VerticalScroll.Value + 3);
                ((Label)panel.Controls[labelIndex]).AutoSize = true;
                coordY += 30;
                labelIndex++;
                // Информация о владельце, заголовок
                panel.Controls.Add(new Label());
                ((Label)panel.Controls[labelIndex]).Text = "Владелец: ";
                ((Label)panel.Controls[labelIndex]).Font = new Font("Univers Else", 12, FontStyle.Bold);
                ((Label)panel.Controls[labelIndex]).ForeColor = Color.Black;
                ((Label)panel.Controls[labelIndex]).Location = new Point(
                    ((Label)panel.Controls[labelIndex-2]).Location.X + ((Label)panel.Controls[labelIndex-2]).Size.Width / 4,
                    coordY - panel.VerticalScroll.Value);
                ((Label)panel.Controls[labelIndex]).AutoSize = true;
                labelIndex++;
                // Информация о владельце, ФИО
                panel.Controls.Add(new Label());
                ((Label)panel.Controls[labelIndex]).Text = "ID_" +
                    searchResults[resultIndex].OwnerID + " " +
                    searchResults[resultIndex].OwnerSecondName + " " +
                    searchResults[resultIndex].OwnerFirstName + " " +
                    searchResults[resultIndex].OwnerMiddleName;
                ((Label)panel.Controls[labelIndex]).Font = new Font("Univers Else", 10);
                ((Label)panel.Controls[labelIndex]).ForeColor = Color.Black;
                ((Label)panel.Controls[labelIndex]).Location = new Point(
                    ((Label)panel.Controls[labelIndex-1]).Location.X + ((Label)panel.Controls[labelIndex-1]).Size.Width + 10,
                    coordY - panel.VerticalScroll.Value);
                ((Label)panel.Controls[labelIndex]).AutoSize = true;
                coordY += 20;
                labelIndex++;
                // Информация о программах, заголовок
                panel.Controls.Add(new Label());
                ((Label)panel.Controls[labelIndex]).Text = "Программы:";
                ((Label)panel.Controls[labelIndex]).Font = new Font("Univers Else", 12, FontStyle.Bold);
                ((Label)panel.Controls[labelIndex]).ForeColor = Color.Black;
                ((Label)panel.Controls[labelIndex]).Location = new Point(
                    ((Label)panel.Controls[labelIndex-2]).Location.X + ((Label)panel.Controls[labelIndex-2]).Size.Width / 3,
                    coordY - panel.VerticalScroll.Value);
                ((Label)panel.Controls[labelIndex]).AutoSize = true;
                coordY += 20;
                labelIndex++;
                int programIndex = 0;
                // Информация о программах, список через цикл
                do
                {
                    //ID и название программы
                    panel.Controls.Add(new Label());
                    ((Label)panel.Controls[labelIndex]).Text = "ID_" +
                        searchResults[resultIndex].ProgramID + " " +
                        searchResults[resultIndex].ProgramName;
                    ((Label)panel.Controls[labelIndex]).Font = new Font("Univers Else", 10);
                    ((Label)panel.Controls[labelIndex]).ForeColor = Color.Black;
                    ((Label)panel.Controls[labelIndex]).Location = new Point(
                        ((Label)panel.Controls[labelIndex-1-2*programIndex]).Location.X + 
                        ((Label)panel.Controls[labelIndex-1-2*programIndex]).Size.Width / 3,
                        coordY - panel.VerticalScroll.Value);
                    ((Label)panel.Controls[labelIndex]).AutoSize = true;
                    labelIndex++;
                    //Id diskProgram
                    panel.Controls.Add(new Label());
                    ((Label)panel.Controls[labelIndex]).Text = " DiskProgID_" +
                        searchResults[resultIndex].DiskProgramID;
                    ((Label)panel.Controls[labelIndex]).Font = new Font("Univers Else", 8);
                    ((Label)panel.Controls[labelIndex]).ForeColor = Color.Gray;
                    ((Label)panel.Controls[labelIndex]).Location = new Point(
                        ((Label)panel.Controls[labelIndex-1]).Location.X + ((Label)panel.Controls[labelIndex-1]).Size.Width,
                        coordY - panel.VerticalScroll.Value+4);
                    ((Label)panel.Controls[labelIndex]).AutoSize = true;
                    coordY += 18;
                    labelIndex++;
                    programIndex++;
                    resultIndex++;
                    if (resultIndex >= searchResults.Count)
                        break;
                } while (currentDisk == searchResults[resultIndex].DiskID);
            }
        }
    }
}
