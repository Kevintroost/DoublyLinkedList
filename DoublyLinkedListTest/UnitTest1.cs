using FluentAssertions;

public class DoubleLinkListTests
{
    [Test]
    public void Add_ShouldIncreaseCount()
    {
        var list = new DoubleLinkList<int>();
        list.Add(1);
        list.Add(2);
        list.Count.Should().Be(2);
    }

    [Test]
    public void IndexOf_ShouldReturnCorrectIndex()
    {
        var list = new DoubleLinkList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.IndexOf(2).Should().Be(1);
    }

    [Test]
    public void Contains_ShouldReturnTrueIfElementExists()
    {
        var list = new DoubleLinkList<int>();
        list.Add(10);
        list.Contains(10).Should().BeTrue();
    }

    [Test]
    public void Contains_ShouldReturnFalseIfElementDoesNotExist()
    {
        var list = new DoubleLinkList<int>();
        list.Add(10);
        list.Contains(5).Should().BeFalse();
    }

    [Test]
    public void Insert_ShouldInsertElementAtCorrectPosition()
    {
        var list = new DoubleLinkList<int>();
        list.Add(1);
        list.Add(3);
        list.Insert(1, 2);
        list[1].Should().Be(2);
    }

    [Test]
    public void Remove_ShouldDecreaseCount()
    {
        var list = new DoubleLinkList<int>();
        list.Add(1);
        list.Add(2);
        list.Remove(1);
        list.Count.Should().Be(1);
    }

    [Test]
    public void RemoveAt_ShouldRemoveCorrectElement()
    {
        var list = new DoubleLinkList<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.RemoveAt(1);
        list[1].Should().Be(3);
    }

    [Test]
    public void Clear_ShouldResetList()
    {
        var list = new DoubleLinkList<int>();
        list.Add(1);
        list.Add(2);
        list.Clear();
        list.Count.Should().Be(0);
    }

    [Test]
    public void Indexer_Get_ShouldReturnCorrectValue()
    {
        var list = new DoubleLinkList<int>();
        list.Add(100);
        list.Add(200);
        list[1].Should().Be(200);
    }

    [Test]
    public void Indexer_Set_ShouldUpdateValue()
    {
        var list = new DoubleLinkList<int>();
        list.Add(5);
        list[0] = 10;
        list[0].Should().Be(10);
    }
}