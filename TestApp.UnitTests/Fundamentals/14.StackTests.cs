using NUnit.Framework;
using TestApp.Fundamentals;


namespace TestApp.UnitTests.Fundamentals
{
    [TestFixture]
    public class StackTests
    {
        public MyStack<object> _stack;

        [SetUp]
        public void Setup()
        {
            _stack = new MyStack<object>();
        }

        [Test]
        public void Push_ReceivesNullArgument_ReturnsArgumentNullException()
        {
            Assert.That(() => _stack.Push(null), Throws.ArgumentNullException);
        }

        [Test]
        public void Push_WhenExecuted_InsertsValueUntoStack()
        {
            _stack.Push(4);
            Assert.That(_stack.Count, Is.EqualTo(1));
        }

        [Test]
        public void Pop_WhenStackIsEmpty_ReturnsInvalidOperationException()
        {
            Assert.That(() => _stack.Pop(), Throws.InvalidOperationException);
        }

        [Test]
        public void Pop_WhenStackIsNotEmpty_RemovesLastValue()
        {
            _stack.Push(1);
            _stack.Push(2);
            _stack.Push(3);
            _stack.Pop();

            Assert.That(_stack.Count, Is.EqualTo(2));
        }

        [Test]
        public void Pop_WhenStackIsNotEmpty_ReturnsLastValue()
        {
            _stack.Push(1);
            _stack.Push(2);
            _stack.Push(3);

            var poppedValue = _stack.Pop();

            Assert.That(poppedValue, Is.EqualTo(3));
        }

        [Test]
        public void Peek_WhenStackIsEmpty_ReturnsInvalidOperationException()
        {
            Assert.That(() => _stack.Peek(), Throws.Exception.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void Peek_WhenStackContainsValue_ReturnsLastAddedValue()
        {
            _stack.Push(1);
            _stack.Push(2);
            _stack.Push(3);

            var peekedValue = _stack.Peek();

            Assert.That(peekedValue, Is.EqualTo(3));
        }

        [Test]
        public void Peek_WhenStackContainsValue_DoesNotRemoveAnyValue()
        {
            _stack.Push(1);
            _stack.Push(2);
            _stack.Push(3);

            _stack.Peek();

            Assert.That(_stack.Count, Is.EqualTo(3));
        }
    }
}
