package com.brianwebb.csc120final.backend;

import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;
import org.vaadin.crudui.crud.CrudListener;

import java.util.Collection;

@Service
@RequiredArgsConstructor
public class TaskService implements CrudListener<Task>
{
    private final TaskRepository repository;

    @Override
    public Collection<Task> findAll() {
        return repository.findAll();
    }

    @Override
    public Task add(Task task) {
        return repository.save(task);
    }

    @Override
    public Task update(Task task) {
        return repository.save(task);
    }

    @Override
    public void delete(Task task) {
        repository.delete(task);
    }
}
