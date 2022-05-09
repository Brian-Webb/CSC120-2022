package com.brianwebb.csc120final.ui;

import com.brianwebb.csc120final.backend.Task;
import com.brianwebb.csc120final.backend.TaskService;
import com.vaadin.flow.component.html.H2;
import com.vaadin.flow.component.orderedlayout.VerticalLayout;
import com.vaadin.flow.router.PageTitle;
import com.vaadin.flow.router.Route;
import org.vaadin.crudui.crud.impl.GridCrud;

import javax.annotation.security.PermitAll;

@PermitAll
@PageTitle("Dashboard | Task Manager")
@Route(value="", layout = MainLayout.class)
public class TasksView extends VerticalLayout {

    public TasksView(TaskService service) {
        var crud  = new GridCrud<>(Task.class, service);
        crud.getGrid().setColumns("title", "dueDate", "completed");
        crud.getCrudFormFactory().setVisibleProperties("title", "dueDate", "completed");

        add(
                new H2("Tasks"),
                crud
        );
    }
}
