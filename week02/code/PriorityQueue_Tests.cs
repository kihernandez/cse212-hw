using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add three items with different priorities.
    // Expected Result: The item with the highest priority is returned first.
    // Defect(s) Found: Found no defects, the test passed because Dequeue() 
    // correclty returns the item with the highest priority.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Apple", 1);
        priorityQueue.Enqueue("Banana", 5);
        priorityQueue.Enqueue("Cherry", 3);

        Assert.AreEqual("Banana", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add three items where two items have the same highest priority.
    // Expected Result: The first item added with the highest priority is returned first.
    // Defect(s) Found: Dequeue() removes the last item with the highest priority
    // instead of the first item with the highest priority. This violates the FIFO
    // requirement when multiple items have the same priority.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Apple", 5);
        priorityQueue.Enqueue("Banana", 5);
        priorityQueue.Enqueue("Cherry", 3);

        Assert.AreEqual("Apple", priorityQueue.Dequeue());
        Assert.AreEqual("Banana", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Add several items with the same priority.
    // Expected Result: Items with the same priority are removed in the same order they were added.
    // Defect(s) Found: Dequeue() does not maintain FIFO order when multiple items
    // have the same highest priority. It removes a later item instead of the item
    // closes to the front of the queue.
    public void TestPriorityQueue_3()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("First", 10);
        priorityQueue.Enqueue("Second", 10);
        priorityQueue.Enqueue("Third", 10);

        Assert.AreEqual("First", priorityQueue.Dequeue());
        Assert.AreEqual("Second", priorityQueue.Dequeue());
        Assert.AreEqual("Third", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue an item from an empty priority queue.
    // Expected Result: An InvalidOperationException is thrown with the message "The queue is empty."
    // Defect(s) Found: Found no defects, the test passed because Dequue() correctly throws an
    // InvalidOperationException with the required error message when the Queue is empty.
    public void TestPriorityQueue_4()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }
}
