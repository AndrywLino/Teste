using System.Collections.Generic;

namespace MeuAcerto.Selecao.KataGildedRose
{
    class GildedRose
    {
        IList<Item> Itens;
        public GildedRose(IList<Item> Itens)
        {
            this.Itens = Itens;
        }

        public void AtualizarQualidade()
        {
            for (var i = 0; i < Itens.Count; i++)
            {
                if (Itens[i].Nome != "Sulfuras, a Mão de Ragnaros")
                {
                    Itens[i].PrazoValidade--;
                    if (Itens[i].Nome != "Queijo Brie Envelhecido" && !Itens[i].Nome.Contains("Ingressos"))
                    {
                        if (Itens[i].PrazoValidade >= 0 && Itens[i].Qualidade > 0 && !Itens[i].Nome.Contains("Conjurado"))
                        {
                            Itens[i].Qualidade--;
                            if (Itens[i].Qualidade < 0)
                                Itens[i].Qualidade = 0;
                        }

                        else if (Itens[i].PrazoValidade < 0 && Itens[i].Qualidade > 0 && !Itens[i].Nome.Contains("Conjurado"))
                        {
                            Itens[i].Qualidade -= 2;
                            if (Itens[i].Qualidade < 0)
                                Itens[i].Qualidade = 0;
                        }
                        else if (Itens[i].Nome.Contains("Conjurado"))
                        {
                            if (Itens[i].PrazoValidade >= 0 && Itens[i].Qualidade > 0)
                            {
                                Itens[i].Qualidade -= 2;
                                if (Itens[i].Qualidade < 0)
                                    Itens[i].Qualidade = 0;
                            }
                            else if (Itens[i].PrazoValidade < 0 && Itens[i].Qualidade > 0)
                            {
                                Itens[i].Qualidade -= 4;
                                if (Itens[i].Qualidade < 0)
                                    Itens[i].Qualidade = 0;
                            }
                        }
                    }
                    else
                    {
                        if (Itens[i].Nome == "Queijo Brie Envelhecido")
                        {
                            if (Itens[i].Qualidade < 50)
                                Itens[i].Qualidade++;
                        }
                        else if (Itens[i].Nome.Contains("Ingressos"))
                        {
                            if (Itens[i].PrazoValidade < 0 && Itens[i].Qualidade <= 50)
                                Itens[i].Qualidade = 0;
                            else if (Itens[i].PrazoValidade > 10 && Itens[i].Qualidade < 50)
                                Itens[i].Qualidade++;
                            else if (Itens[i].PrazoValidade <= 5 && Itens[i].Qualidade < 50)
                            {
                                Itens[i].Qualidade += 3;
                                if (Itens[i].Qualidade > 50)
                                    Itens[i].Qualidade = 50;
                            }
                            else if (Itens[i].PrazoValidade <= 10 && Itens[i].Qualidade < 50)
                            {
                                Itens[i].Qualidade += 2;
                                if (Itens[i].Qualidade > 50)
                                    Itens[i].Qualidade = 50;
                            }
                        }
                    }
                }
            }
        }
    }
}
