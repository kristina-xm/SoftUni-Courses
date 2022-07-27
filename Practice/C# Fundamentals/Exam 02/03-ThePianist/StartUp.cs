using System;
using System.Collections.Generic;
using System.Linq;

namespace ThePianist
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            int initialNumberOfPieces = int.Parse(Console.ReadLine());

            List<Music> manyPieces = new List<Music>();

            for (int i = 0; i < initialNumberOfPieces; i++)
            {
                string[] inputPiece = Console.ReadLine().Split('|').ToArray();

                string nameOfPiece = inputPiece[0];
                string composer = inputPiece[1];
                string key = inputPiece[2];

                Music piece = new Music(nameOfPiece, composer, key);
                manyPieces.Add(piece);

            }

            string[] command = Console.ReadLine().Split('|');

            while (command[0] != "Stop")
            {
                string cmdType = command[0];

                if (cmdType == "Add")
                {
                    string name = command[1];
                    string composer = command[2];
                    string key = command[3];

                    if (manyPieces.Any(t => t.Piece == name))
                    {
                        Console.WriteLine($"{name} is already in the collection!");
                    }
                    else
                    {
                        Console.WriteLine($"{name} by {composer} in {key} added to the collection!");
                        Music newPiece = new Music(name, composer, key);
                        manyPieces.Add(newPiece);
                    }
                }
                else if (cmdType == "Remove")
                {
                    string piece = command[1];
                    int pieceIndex = 0;

                    foreach (Music music in manyPieces)
                    {
                        if (music.Piece == piece)
                        {
                            manyPieces.Remove(music);
                            Console.WriteLine($"Successfully removed {piece}!");
                            pieceIndex++;
                            break;
                        }
                    }

                    if (pieceIndex == 0)
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }
                }
                else if (cmdType == "ChangeKey")
                {
                    string piece = command[1];
                    string newKey = command[2];

                    int check = 0;
                    foreach (Music music in manyPieces)
                    {
                        if (music.Piece == piece)
                        {
                            music.Key = newKey;
                            check++;
                            Console.WriteLine($"Changed the key of {piece} to {newKey}!");
                            break;
                        }
                    }

                    if (check == 0)
                    {
                        Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                    }

                }
                command = Console.ReadLine().Split('|');
            }

            foreach (Music item in manyPieces)
            {
                Console.WriteLine($"{item.Piece} -> Composer: {item.Composer}, Key: {item.Key}");
            }
        }
    }
}
