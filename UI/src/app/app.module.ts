import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ListIndexComponent } from './components/list/list-index/list-index.component';
import { ListDetailsComponent } from './components/list/list-details/list-details.component';
import { ListCreateComponent } from './components/list/list-create/list-create.component';
import { ListUpdateComponent } from './components/list/list-update/list-update.component';
import { ItemIndexComponent } from './components/item/item-index/item-index.component';
import { ItemDetailsComponent } from './components/item/item-details/item-details.component';
import { ItemCreateComponent } from './components/item/item-create/item-create.component';
import { ItemUpdateComponent } from './components/item/item-update/item-update.component';

@NgModule({
  declarations: [
    AppComponent,
    ListIndexComponent,
    ListDetailsComponent,
    ListCreateComponent,
    ListUpdateComponent,
    ItemIndexComponent,
    ItemDetailsComponent,
    ItemCreateComponent,
    ItemUpdateComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
