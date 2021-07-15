import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { Item } from 'src/app/models/item';
import { ItemService } from 'src/app/services/item.service';

@Component({
  selector: 'app-item-create',
  templateUrl: './item-create.component.html',
  styleUrls: ['./item-create.component.scss']
})
export class ItemCreateComponent implements OnInit {

  public name: string = "";
  @Input() listId: number = 0;
  @Output() newItemEvent = new EventEmitter<Item>();

  constructor(private _itemService: ItemService, private _router: Router) { }

  ngOnInit(): void {
  }

  public save(): void{
    console.log(this.name);
    this._itemService.create(this.listId, this.name)
      .subscribe(item => {
        this.newItemEvent.emit(item);
      })
  }

}
