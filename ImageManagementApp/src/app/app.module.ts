import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
//import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { ImageListComponent } from './components/image-list/image-list.component';
import { ImageFormComponent } from './components/image-form/image-form.component';

@NgModule({
    declarations: [
        AppComponent,
        ImageListComponent,
        ImageFormComponent
    ],
    imports: [
        BrowserModule,
        HttpClientModule,
        ReactiveFormsModule
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }
