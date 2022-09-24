using System;
using System.Text;
using System.Collections.Generic;

namespace DesignPatterns.Behavioral.Command
{
    class Program
    {
        static void Main(string[] args)
        {
            var app = new Application();
            app.Editor.Text = "The quick brown fox jumped over the lazy dog";

            Console.WriteLine("Initially:");
            Console.WriteLine(app.Editor);

            Console.WriteLine("\nCopy and paste:");
            app.Editor.SelectedPosition = Tuple.Create(0, 3);
            app.Click("Copy");
            app.Editor.SelectedPosition = null;
            app.KeyPress("Ctrl+V");
            Console.WriteLine(app.Editor);

            Console.WriteLine("\nCut and paste:");
            app.Editor.SelectedPosition = Tuple.Create(0, 16);
            app.KeyPress("Ctrl+X");
            app.Editor.SelectedPosition = Tuple.Create(16, 9);
            app.Click("Paste");
            Console.WriteLine(app.Editor);

            Console.WriteLine("\nUndo:");
            app.Click("Undo");
            Console.WriteLine(app.Editor);

            Console.WriteLine("\nUndo:");
            app.KeyPress("Ctrl+Z");
            Console.WriteLine(app.Editor);

            Console.WriteLine("\nUndo:");
            app.Click("Undo");
            Console.WriteLine(app.Editor);
        }
    }

    class Application
    {
        public string Clipboard;
        public Editor Editor = new Editor();
        private Stack<UndoableCommand> history = new Stack<UndoableCommand>();

        private void executeCommand(Command command)
        {
            command.Execute();
            if (command is UndoableCommand)
            {
                history.Push((UndoableCommand) command);
            }
        }

        private Command createCommand(string name)
        {
            switch(name) 
            {
                case "Copy":
                    return new CopyCommand(this, Editor);
                case "Cut":
                    return new CutCommand(this, Editor);
                case "Paste":
                    return new PasteCommand(this, Editor);
                case "Undo":
                    return new UndoCommand(this, Editor);
                case "Ctrl+C":
                    return new CopyCommand(this, Editor);
                case "Ctrl+X":
                    return new CutCommand(this, Editor);
                case "Ctrl+V":
                    return new PasteCommand(this, Editor);
                case "Ctrl+Z":
                    return new UndoCommand(this, Editor);
                default:
                    throw new ArgumentException("Invalid command: " + name);
            }

        }

        public void Click(string button)
        {

            this.executeCommand(createCommand(button));
        }

        public void KeyPress(string key)
        {
            this.executeCommand(createCommand(key));
        }

        public void Undo()
        {
            if (history.Count == 0) return;

            history.Pop().Undo();
        }
    }

    abstract class Command
    {
        protected Application app;
        protected Editor editor;

        public Command(Application app, Editor editor)
        {
            this.app = app;
            this.editor = editor;
        }

        public abstract void Execute();
    }

    abstract class UndoableCommand : Command
    {
        protected string backup;

        public UndoableCommand(Application app, Editor editor): base(app, editor)
        {
        }

        public void Backup()
        {
            backup = editor.Text;
        }

        public void Undo()
        {
            editor.Text = backup;
        }

        public override void Execute()
        {
            Backup();
            _execute();
        }

        protected abstract void _execute();
    }

    class CopyCommand: Command
    {
        public CopyCommand(Application app, Editor editor): base(app, editor)
        {
        }

        public override void Execute()
        {
            app.Clipboard = editor.GetSelection();
        }
    }

    class CutCommand: UndoableCommand
    {
        public CutCommand(Application app, Editor editor): base(app, editor)
        {
        }
        
        protected override void _execute()
        {
            app.Clipboard = editor.GetSelection();
            editor.DeleteSelection();
        }
    }

    class PasteCommand: UndoableCommand
    {
        public PasteCommand(Application app, Editor editor): base(app, editor)
        {
        }

        protected override void _execute()
        {
            editor.ReplaceOrAppend(app.Clipboard);
        }
    }

    class UndoCommand: Command
    {
        public UndoCommand(Application app, Editor editor): base(app, editor)
        {
        }
        
        public override void Execute()
        {
            app.Undo();
        }
    }

    class Editor
    {
        public string Text;
        public Tuple<int, int> SelectedPosition;

        public string GetSelection()
        {
            return Text.Substring(SelectedPosition.Item1, SelectedPosition.Item2);
        }

        public void DeleteSelection()
        {
            ReplaceSelection("");
        }

        public void ReplaceOrAppend(string target)
        {
            if (SelectedPosition == null) 
            {
                Text += target;
            }
            else 
            {
                ReplaceSelection(target);
            }
        }

        public void ReplaceSelection(string target)
        {
            var aStringBuilder = new StringBuilder(Text);
            aStringBuilder.Remove(SelectedPosition.Item1, SelectedPosition.Item2);
            aStringBuilder.Insert(SelectedPosition.Item1, target);
            Text = aStringBuilder.ToString();
        }

        public override string ToString()
        {
            return "Editor Content: " + Text;
        }
    }
}