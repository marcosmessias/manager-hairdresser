import { Injectable } from '@angular/core';
import { User } from '@models/user.model';
import { BehaviorSubject } from 'rxjs';
import { LocalStorageRefService } from './local-storage-ref.service';

@Injectable({ providedIn: 'root' })
export class LocalStorageService {
  private _localStorage: Storage;

  private _myData$ = new BehaviorSubject<User>({});
  myData$ = this._myData$.asObservable();

  constructor(_localStorageRefService: LocalStorageRefService) {
    this._localStorage = _localStorageRefService.localStorage;
  }

  setInfo(data: User): void {
    const jsonData: string = JSON.stringify(data);
    this._localStorage.setItem('currentUser', jsonData);
    this._myData$.next(data);
  }

  loadInfo(): void {
    const jsonData: string | null = this._localStorage.getItem('currentUser');
    if (jsonData) {
      const data = JSON.parse(jsonData);
      this._myData$.next(data);
    }
  }

  clearInfo() {
    this._localStorage.removeItem('currentUser');
    this._myData$.next({});
  }

  clearAllLocalStorage(): void {
    this._localStorage.clear();
    this._myData$.next({});
  }
}
