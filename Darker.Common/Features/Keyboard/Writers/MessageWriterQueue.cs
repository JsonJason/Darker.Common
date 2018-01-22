using System.Collections.Generic;

namespace Darker.Common
{
    /// <summary>
    /// Enqueues a collection of keyboard commands and executes them
    /// </summary>
    public class MessageWriterQueue
    {
        private readonly MessageWriterCommandFactory _factory;

        /// <summary>
        /// Constructs a message writer queue
        /// </summary>
        /// <param name="factory">the factory to get commands from</param>
        public MessageWriterQueue(MessageWriterCommandFactory factory)
        {
            _factory = factory;
        }

        /// <summary>
        /// Writes a message to the queue
        /// </summary>
        /// <param name="message">Message to write</param>
        /// <returns>The fluent self reference</returns>
        public MessageWriterQueue Write(string message)
        {
            for (var i = 0; i < message.Length; i++)
                _commands.Enqueue(
                    _factory.CreateLetterCommand(message[i]));
            return this;
        }

        /// <summary>
        /// Presses a key a number of times on a virtual keyboard
        /// </summary>
        /// <param name="key">The key to press</param>
        /// <param name="times">Times to press it</param>
        /// <returns>The fluent self reference</returns>
        public MessageWriterQueue PressXTimes(SpecialKeys key, int times)
        {
            for (var i = 0; i < times; i++)
                _commands.Enqueue(
                    _factory.CreateSpecialKeyCommand(key));
            return this;
        }

        /// <summary>
        /// Presses a key on a virtual keyboard
        /// </summary>
        /// <param name="key">The key to press</param>
        /// <returns>The fluent self reference</returns>
        public MessageWriterQueue Press(SpecialKeys key)
        {
            _commands.Enqueue(
                _factory.CreateSpecialKeyCommand(key));
            return this;
        }

        /// <summary>
        /// Presses a key on a virtual keyboard
        /// </summary>
        /// <param name="key">The key to press</param>
        /// <returns>The fluent self reference</returns>
        public MessageWriterQueue Press(char key)
        {
            _commands.Enqueue(
                _factory.CreateLetterCommand(key));
            return this;
        }

        /// <summary>
        /// Does this queue have additional tasks to perform?
        /// </summary>
        public bool HasMoreToWrite
        {
            get { return _commands.Count > 0; }
        }

        /// <summary>
        /// Perform the next queued action
        /// </summary>
        public void PerformNextAction()
        {
            if (!HasMoreToWrite) return;

            var nextCommand = _commands.Dequeue();
            nextCommand.Execute();
        }

        private readonly Queue<Command> _commands = new Queue<Command>();
    }

}
