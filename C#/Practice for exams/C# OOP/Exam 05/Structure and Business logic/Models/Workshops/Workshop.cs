namespace Easter.Models.Workshops
{
    using Easter.Models.Bunnies.Contracts;
    using Easter.Models.Eggs.Contracts;
    using Easter.Models.Workshops.Contracts;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Workshop : IWorkshop
    {
        public Workshop()
        {

        }
        public void Color(IEgg egg, IBunny bunny)
        {
            if (bunny.Energy > 0 && bunny.Dyes.Any(d => !d.IsFinished()))
            {
                while (!egg.IsDone() || (bunny.Energy > 0 || bunny.Dyes.Any(d => !d.IsFinished())))
                {
                    if (egg.EnergyRequired <= 0)
                    {

                        break;
                    }

                    if (bunny.Energy <= 0)
                    {
                        break;
                    }

                    foreach (var dye in bunny.Dyes)
                    {
                        if (egg.EnergyRequired <= 0)
                        {
                            
                            break;
                        }

                        if (bunny.Energy <= 0)
                        {
                            break;
                        }

                        while (dye.Power > 0)
                        {
                            if (dye.Power <= 0)
                            {
                                if (bunny.Dyes.Any(d => !d.IsFinished()))
                                {
                                    break;
                                }
                                else
                                {
                                    return;
                                }
                            }

                            bunny.Work();
                            if (bunny.Energy <= 0)
                            {
                                break;
                            }
                            egg.GetColored();
                            
                            if (egg.EnergyRequired <= 0)
                            {
                                break;
                            }
                        }

                       
                    }

                   
                }
            }
        }
    }
}
