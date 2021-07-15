import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Item } from 'src/app/models/item';
import { ItemService } from 'src/app/services/item.service';

@Component({
  selector: 'app-item-details',
  templateUrl: './item-details.component.html',
  styleUrls: ['./item-details.component.scss']
})
export class ItemDetailsComponent implements OnInit {

  public isEditMode: boolean = false;
  @Input() public item: Item = new Item(0, "", 0, 0, false);
  @Output() deleteItemEvent = new EventEmitter<Item>();

  constructor(private _itemService: ItemService) { }

  ngOnInit(): void {
  }

  public toggledEdit(){
    this.isEditMode = !this.isEditMode;
  }

  public delete(){
    this._itemService.deleteById(this.item.id).subscribe(r =>
      {
        this.deleteItemEvent.emit(this.item);
      }
    )
  }

  public saveIsChecked(value: boolean){
    this._itemService.update(this.item.id, "", value).subscribe();
  }

  public saveName(){
    this._itemService.update(this.item.id, this.item.name, undefined).subscribe(r => {
      this.toggledEdit();
    })
  }
  
}
