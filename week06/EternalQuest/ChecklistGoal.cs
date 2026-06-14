using System;

public class ChecklistGoal : Goal
{
    private int _bonus;
    private int _targetCount;
    private int _currentCount;

    public ChecklistGoal(
        string name,
        string description,
        int points,
        int bonus,
        int targetCount)
        : base(name, description, points)
    {
        _bonus = bonus;
        _targetCount = targetCount;
        _currentCount = 0;
    }

    public ChecklistGoal(
        string name,
        string description,
        int points,
        int bonus,
        int targetCount,
        int currentCount)
        : base(name, description, points)
    {
        _bonus = bonus;
        _targetCount = targetCount;
        _currentCount = currentCount;
    }

    public override int RecordEvent()
    {
        if (_currentCount >= _targetCount)
        {
            return 0;
        }

        _currentCount++;

        if (_currentCount == _targetCount)
        {
            return _points + _bonus;
        }

        return _points;
    }

    public override bool IsComplete()
    {
        return _currentCount >= _targetCount;
    }

    public override string GetStatus()
    {
        string mark = IsComplete() ? "X" : " ";

        return $"[{mark}] {_shortName} ({_description}) -- Completed {_currentCount}/{_targetCount}";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal|{_shortName}|{_description}|{_points}|{_bonus}|{_targetCount}|{_currentCount}";
    }
}